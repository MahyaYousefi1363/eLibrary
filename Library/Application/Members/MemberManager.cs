using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using CSharpFunctionalExtensions;
using eLibrary.Library.Application.Members.Contracts;
using eLibrary.Library.Application.Members.Dtos;
using eLibrary.Library.Domain.Primitives.Contracts;
using eLibrary.Library.Domain.Members;

namespace eLibrary.Library.Application.Members
{
    public class MemberManager(
        IMemberRepository memberRepository,
        IMapper mapper,
        IValidator<MemberForCreateDto> memberForCreateValidator
    ) : IMemberManager
    {
        public async Task<Result> CreateMemberAsync(MemberForCreateDto memberForCreateDto)
        {
            var ValidationRequest = memberForCreateValidator.Validate(memberForCreateDto);
            if (!ValidationRequest.IsValid)
            {
                return Result.Failure("Member Is Invalid");
            }
            var member = new Member(
                memberForCreateDto.NationalCode,
                memberForCreateDto.FullName,
                memberForCreateDto.MobileNumber,
                memberForCreateDto.Address
            );
            await memberRepository.CreateEntityAsync(member);
            return Result.Success();
        }
    }
}
