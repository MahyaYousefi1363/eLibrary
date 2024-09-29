using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Library.Domain.Primitives.Contracts
{
    public interface IRepository<TEntity, TID>
        where TEntity : IEntity<TID>
        where TID : notnull
    {        
        Task CreateEntityAsync(TEntity entity);
    }
}