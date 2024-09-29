using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Execution;
using eLibrary.Library.Domain.Members;

namespace eLibrary.Library.Infrastructure.Persistence.Repositories
{
    public class MemberSqlRepository : SqlRepository<Domain.Members.Member, Guid>, IMemberRepository
    {
        public MemberSqlRepository(LibraryContext context):base(context){

        }

        public async override Task CreateEntityAsync(Domain.Members.Member entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}