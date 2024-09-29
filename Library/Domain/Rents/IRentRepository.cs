using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using eLibrary.Library.Domain.Primitives.Contracts;

namespace eLibrary.Library.Domain.Rents
{
    public interface IRentRepository : IRepository<Rent, Guid> { 
        int GetActiveRentsCountForMemberNationalCode(string memberNationalCode);
        int GetActiveRentForBookIsbn(string bookIsbn);
        Task<Rent?> GetEntityByIdAsync(Guid rentId);
        Task ReturnRent(Rent rent);
        Task<Result<IReadOnlyList<Rent>>> GetExpiredRentsList(int ExpireRange);
    }
}
