using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Primitives;
using eLibrary.Library.Domain.Primitives.Contracts;
using eLibrary.Library.Domain.Books;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Library.Infrastructure.Persistence.Repositories
{
    public abstract class SqlRepository<TEntity,TID> : IRepository<TEntity, TID>
        where TEntity : Entity<TID>
        where TID : notnull
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _set;

        protected SqlRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public abstract Task CreateEntityAsync(TEntity entity);
    }
}
