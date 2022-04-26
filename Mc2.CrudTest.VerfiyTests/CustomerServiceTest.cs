using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Persistence;
using Mc2.CrudTest.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mc2.CrudTest.VerfiyTests
{
    public class CustomerServiceTest
    {
        [Fact]
        public void CountTest()
        {
            // Todo: Refer to readme.md 
            // Arrange
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "CustomersDatabase")
           .Options;
            var context = new DataBaseContext(options);
            Seed(context);

            //Arrange

            CustomerService customerService = new CustomerService(context);

            //act
            var customers = customerService.GetCustomers2();

            //assret
            Assert.Equal(3, customers.Count);

            //using (var context = new DataBaseContext(options))
            //{
            //    //Arrange

            //    CustomerService customerService = new CustomerService(context);

            //    //act
            //    var customers = customerService.GetCustomers2();

            //    //assret
            //    Assert.Equal(3, customers.Count);
            //}

        }
        private void Seed(DataBaseContext context)
        {
            context.Customers.AddRange(
                   new Customer
                   {
                       Firstname = "ali",
                       Lastname = "rad",
                       BankAccountNumber = 343242,
                       Email = "a@yahoo.com",
                       IsRemoved = false
                   },
                     new Customer
                     {
                         Firstname = "ali1",
                         Lastname = "rad1",
                         BankAccountNumber = 3432421,
                         Email = "a1@yahoo.com",
                         IsRemoved = false
                     },
                       new Customer
                       {
                           Firstname = "ali2",
                           Lastname = "rad2",
                           BankAccountNumber = 3432422,
                           Email = "a2@yahoo.com",
                           IsRemoved = false
                       }
               );
            context.SaveChanges();
        }

        [Fact]
        public void TaskGetOkResult()
        {
            // Todo: Refer to readme.md 
            // Arrange
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "CustomersDatabase")
           .Options;
            var context = new DataBaseContext(options);
            Seed(context);

            //Arrange
            CustomerService customerService = new CustomerService(context);


            //act
            var customers = customerService.GetCustomers2();


            //assert
            Assert.IsType<List<CustomerDto>>(customers);
        }
    }
}
