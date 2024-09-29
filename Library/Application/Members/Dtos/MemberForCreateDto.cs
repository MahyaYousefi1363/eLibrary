using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Library.Application.Members.Dtos
{
    public record MemberForCreateDto(string NationalCode,string FullName,string MobileNumber,string Address);
}