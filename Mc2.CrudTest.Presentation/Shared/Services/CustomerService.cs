using Mc2.CrudTest.Common;
using Mc2.CrudTest.Services.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Services
{
    public interface ICustomerService
    {
        ResultDto AddToCustomer(CustomerDto customer);
        ResultDto RemoveFromCustomer(long customerId);
        ResultDto<List<CustomerDto>> GetCustomers();
        List<CustomerDto> GetCustomers2();


    }
    public class CustomerService : ICustomerService
    {
        private readonly IDataBaseContext _context;
        public CustomerService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto AddToCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public ResultDto<List<CustomerDto>> GetCustomers()
        {
            var customers = _context
               .Customers
               .ToList()
               .Select(p => new CustomerDto
               {
                   Id = p.Id,
                   Firstname=p.Firstname,
                   Lastname=p.Lastname,
                   BankAccountNumber=p.BankAccountNumber,
                   DateOfBirth=p.DateOfBirth,
                   Email=p.Email,
                   PhoneNumber=p.PhoneNumber,
                   
               }
               ).ToList();

            return new ResultDto<List<CustomerDto>>
            {
                Data = customers,
                IsSuccess = false,
                Message = "",
            };
        }
        public List<CustomerDto> GetCustomers2()
        {
            var customers = _context
               .Customers
               .ToList()
               .Select(p => new CustomerDto
               {
                   Id = p.Id,
                   Firstname = p.Firstname,
                   Lastname = p.Lastname,
                   BankAccountNumber = p.BankAccountNumber,
                   DateOfBirth = p.DateOfBirth,
                   Email = p.Email,
                   PhoneNumber = p.PhoneNumber,

               }
               ).ToList();

            return customers;
        }

        public ResultDto RemoveFromCustomer(long customerId)
        {
            throw new NotImplementedException();
        }
    }
}
