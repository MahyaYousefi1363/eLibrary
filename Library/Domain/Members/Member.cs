using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Primitives;

namespace eLibrary.Library.Domain.Members
{
    public class Member : Entity<Guid>
    {
        public string NationalCode { get; private set; }
        public string FullName { get; private set; }
        public string MobileNumber { get; private set; }
        public string Address { get; private set; }

        public Member(string nationalCode, string fullName, string mobileNumber, string address)
            : base(Guid.NewGuid())
        {
            NationalCode = nationalCode;
            FullName = fullName;
            MobileNumber = mobileNumber;
            Address = address;
        }
    }
}
