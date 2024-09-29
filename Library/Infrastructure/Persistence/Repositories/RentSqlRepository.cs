using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using eLibrary.Library.Domain.Rents;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Library.Infrastructure.Persistence.Repositories
{
    public class RentSqlRepository : SqlRepository<Rent,Guid>,IRentRepository
    {    
        public RentSqlRepository(LibraryContext context):base(context)
        {

        }     
        public int GetActiveRentsCountForMemberNationalCode(string memberNationalCode)
        {           
            return _set.Where(rents=>rents.MemberNationalCode==memberNationalCode).Where(rents=>!rents.IsReturned).Count();
        }
        public int GetActiveRentForBookIsbn(string bookIsbn)
        {
            return _set.Where(rents=>rents.BookIsbn==bookIsbn).Where(rents=>!rents.IsReturned).Count();
        }
        public override async Task CreateEntityAsync(Rent rent)
        {
            await _set.AddAsync(rent);
            await _context.SaveChangesAsync();
        }       

        public async Task<Rent?> GetEntityByIdAsync(Guid rentId)
        {
            return await _set.FindAsync(rentId);
        }

        public async Task ReturnRent(Rent rent){
            _context.Entry(rent).State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Result<IReadOnlyList<Rent>>> GetExpiredRentsList(int ExpireRangeDaysCount)
        {
            var result = await _set.Where(rents=>!rents.IsReturned).Where(rents=>(DateTimeOffset.Now-rents.RentDate).Days>ExpireRangeDaysCount).ToListAsync();
            return result.ToImmutableList();
        }
    }
}