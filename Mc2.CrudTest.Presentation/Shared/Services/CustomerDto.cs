using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Services
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string DateOfBirth { get; set; }
        public int RegionCode { get; set; }
        public long PhoneNumber { get; set; }

        public string Email { get; set; }
        public long BankAccountNumber { get; set; }
    }
}
