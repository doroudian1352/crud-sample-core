﻿using System;
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
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
