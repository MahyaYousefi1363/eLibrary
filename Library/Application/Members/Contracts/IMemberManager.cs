using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using eLibrary.Library.Application.Members.Dtos;

namespace eLibrary.Library.Application.Members.Contracts
{
    public interface IMemberManager
    {
        public Task<Result> CreateMemberAsync(MemberForCreateDto memberForCreateDto);
    }
}