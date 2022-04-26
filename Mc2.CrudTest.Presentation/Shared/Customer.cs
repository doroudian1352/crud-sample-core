using System;
using System.Globalization;

namespace Mc2.CrudTest.Domain
{
    public class Customer:BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string DateOfBirth { get; set; }
        public int RegionCode { get; set; }
        public long PhoneNumber { get; set; }

        public string Email { get; set; }
        public long BankAccountNumber { get; set; }

      
    }
}
