using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Primitives.Contracts;

namespace eLibrary.Library.Domain.Members
{
    public interface IMemberRepository : IRepository<Member, Guid> { }
}
