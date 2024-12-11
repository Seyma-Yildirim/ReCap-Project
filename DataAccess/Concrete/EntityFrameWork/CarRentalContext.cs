using Core.Entities.Concrete;
using Entities.Concrete.Cars;
using Entities.Concrete.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\Mssqllocaldb;Database=CarRental;Trusted_Connection=true;");
        }
        public DbSet<Car> Cars { get;set; }
        public DbSet<Brand>Brands { get;set; }
        public DbSet<Color>Colors { get;set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Rental>Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        
    


    }
}
