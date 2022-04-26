using Mc2.CrudTest.Common;
using Mc2.CrudTest.Domain;
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
        ResultDto<long> AddToCustomer(CustomerDto customer);
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

        public ResultDto<long> AddToCustomer(CustomerDto customer)
        {
            Customer newCustomer = new Customer() {
                Firstname=customer.Firstname,
                Lastname=customer.Lastname,
                BankAccountNumber=customer.BankAccountNumber,
                PhoneNumber=customer.PhoneNumber,
                RegionCode=customer.RegionCode,
                Email =customer.Email,
                IsRemoved=false,
                DateOfBirth="1356/12/01",
                InsertTime=DateTime.Today,
            };
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return new ResultDto<long>()
            {
                Data = newCustomer.Id ,
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد",
            };
            
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
               .Where(cu=>cu.IsRemoved==false)
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
                   RegionCode = p.RegionCode,

               }
               ).ToList();

            return customers;
        }

        public ResultDto RemoveFromCustomer(long customerId)
        {
            Customer customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            customer.RemoveTime = DateTime.Now;
            customer.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
