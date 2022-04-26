using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Persistence;
using Mc2.CrudTest.Services;
using Mc2.CrudTest.Services.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests
    {
        
        [Fact]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            // Todo: Refer to readme.md 
            // Arrange
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "CustomersDatabase")
           .Options;
            using(var context=new DataBaseContext(options))
            {
                //Arrange
                context.Customers.AddRange(
                    new Customer { 
                    Firstname="ali",
                    Lastname="rad",
                    BankAccountNumber=343242,
                    Email="a@yahoo.com",
                    IsRemoved=false
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
                CustomerService customerService = new CustomerService(context);

                //act
                var customers = customerService.GetCustomers2();

                //assret
                Assert.Equals(3, customers.Count);
            }
       

        }
        
       

        // Please create more tests based on project requirements as per in readme.md
    }
}
