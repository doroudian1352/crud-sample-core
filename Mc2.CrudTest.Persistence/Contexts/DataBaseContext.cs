//using Bugeto_Store.Application.Interfaces.Contexts;
//using Bugeto_Store.Common.Roles;
//using Bugeto_Store.Domain.Entities.Carts;
//using Bugeto_Store.Domain.Entities.Finances;
//using Bugeto_Store.Domain.Entities.HomePages;
//using Bugeto_Store.Domain.Entities.Orders;
//using Bugeto_Store.Domain.Entities.Products;
//using Bugeto_Store.Domain.Entities.Users;
//using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Services.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            //Seed Data
            SeedData(modelBuilder);


            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<Customer>().HasIndex(u => u.Email).IsUnique();
 
            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }
 
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
          
        }

    }
}
