using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eLibrary.Library.Application.Members.Dtos;
using eLibrary.Library.Domain.Members;

namespace eLibrary.Library.Application.Members
{
    public class MemberMapper:Profile
    {
        public MemberMapper()
        {
            CreateMap<Member,MemberForCreateDto>();
        }
    }
}