using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarCoffee.Data.Model;
using System;
 
namespace SolarCoffee.Data
{
    public class SolarDbContext : IdentityDbContext
    {
        public SolarDbContext() { }
        public SolarDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public virtual DbSet<Customer> Cusomers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
    }
}
