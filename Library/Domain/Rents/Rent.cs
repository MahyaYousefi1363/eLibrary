using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Primitives;

namespace eLibrary.Library.Domain.Rents
{
    public class Rent : Entity<Guid>
    {
        public string MemberNationalCode{get;private set;}
        public string BookIsbn{get; private set;}
        public DateTimeOffset RentDate{get;private set;}
        public DateTimeOffset ReturnDate{get;set;}
        public bool IsReturned{get;set;}
        public Rent(string memberNationalCode,string bookIsbn,DateTimeOffset rentDate,DateTimeOffset returnDate,bool isReturned):base(Guid.NewGuid())
        {
            MemberNationalCode=memberNationalCode;
            BookIsbn=bookIsbn;
            RentDate=rentDate;
            ReturnDate=returnDate;
            IsReturned=isReturned;    
        }
    }
}