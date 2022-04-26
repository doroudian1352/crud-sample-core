using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Mc2.CrudTest.Domain
{
    public class Customer:BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Firstname { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Lastname { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string DateOfBirth { get; set; }

        public int RegionCode { get; set; }
        public long PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        public long BankAccountNumber { get; set; }

      
    }
}
