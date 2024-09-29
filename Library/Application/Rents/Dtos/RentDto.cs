using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Library.Application.Rents.Dtos
{
    public record RentDto(string MemberNationalCode,string BookIsbn,DateTimeOffset RentDate,DateTimeOffset ReturnDate,bool IsReturned);
}