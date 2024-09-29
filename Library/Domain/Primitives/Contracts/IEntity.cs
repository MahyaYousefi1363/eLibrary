using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Library.Domain.Primitives.Contracts
{
    public interface IEntity<TID>
        where TID : notnull
    {
        TID Id { get; }
    }
}