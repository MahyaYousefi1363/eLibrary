using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using eLibrary.Library.Application.Rents.Dtos;
using eLibrary.Library.Domain.Rents;

namespace eLibrary.Library.Application.Rents.Contracts
{
    public interface IRentManager
    {
        public Task<Result> CreateRentAsync(RentForCreateDto rentForCreateDto);
        public Task<Result> ReturnRent(Guid rentId);
        public Task<Result<IReadOnlyList<RentDto>>> GetExpiredRentsList();
    }
}