using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using eLibrary.Library.Application.Rents.Contracts;
using eLibrary.Library.Application.Rents.Dtos;
using eLibrary.Library.Application.Validators;
using eLibrary.Library.Domain.Rents;
using FluentValidation;

namespace eLibrary.Library.Application.Rents
{
    public class RentManager(
        IConfiguration configuration,
        IRentRepository rentRepository,
        IMapper mapper,
        IValidator<RentForCreateDto> rentForCreateValidator
    ) : IRentManager
    {        
        public async Task<Result> CreateRentAsync(RentForCreateDto rentForCreateDto)
        {
            
            var ValidationRequest=rentForCreateValidator.Validate(rentForCreateDto);
            if(!ValidationRequest.IsValid){
                return Result.Failure("Rent Is Invalid!");
            }

            var MaxActiveRentForMember=configuration.GetValue<int>("ActiveRentRestriction");
            if(rentRepository.GetActiveRentsCountForMemberNationalCode(rentForCreateDto.MemberNationalCode)>=MaxActiveRentForMember)
            {
                return Result.Failure($"the Max Permitted Rent For Member is {MaxActiveRentForMember}!");
            }
            var rent=new Rent(
                rentForCreateDto.MemberNationalCode,
                rentForCreateDto.BookIsbn,
                rentForCreateDto.RentDate,
                rentForCreateDto.ReturnDate,
                rentForCreateDto.IsReturned
            );

            await rentRepository.CreateEntityAsync(rent);
            return Result.Success();
        }
        
        public async Task<Result> ReturnRent(Guid rentId)
        {
            var rent = await rentRepository.GetEntityByIdAsync(rentId);
            if (rent is null)
            {
                return Result.Failure("rent not found!");
            }
            rent.ReturnDate=DateTimeOffset.Now;
            rent.IsReturned=true;
            await rentRepository.ReturnRent(rent);
            return Result.Success();
        }

        public async Task<Result<IReadOnlyList<RentDto>>> GetExpiredRentsList()
        {
            var ExpireRangeDaysCount=configuration.GetValue<int>("ExpireRangeDaysCount");
            var ExpiredRentsList=await rentRepository.GetExpiredRentsList(ExpireRangeDaysCount);
            
            var ExpiredRentDtosList=mapper.Map<IReadOnlyList<RentDto>>(ExpiredRentsList);
            return Result.Success(ExpiredRentDtosList);
        }

    }
}
