using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Primitives.Contracts;

namespace eLibrary.Library.Domain.Primitives
{
    public abstract class Entity<TID> : IEntity<TID>
        where TID : notnull
    {
        public TID Id { get; init; }

        public Entity(TID id)
        {
            Id = id;
        }
    }
}