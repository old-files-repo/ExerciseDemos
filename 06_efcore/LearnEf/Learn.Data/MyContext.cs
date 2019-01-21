using System;
using System.Collections.Generic;
using System.Text;
using Learn.Domains;
using Microsoft.EntityFrameworkCore;

namespace Learn.Data
{
    public class MyContext : DbContext
    {
        //public MyContext(DbContextOptions<MyContext> options)
        //: base(options)
        //{

        //}

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CompanyCity> CompanyCities { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyCity>()
                .HasKey(c => new { c.CompanyId, c.CityId });

            modelBuilder.Entity<CompanyCity>().HasOne(x => x.Company)
                .WithMany(x => x.CompanyCities).HasForeignKey(x => x.CompanyId);
            modelBuilder.Entity<CompanyCity>().HasOne(x => x.City)
                .WithMany(x => x.CompanyCities).HasForeignKey(x => x.CityId);

            modelBuilder.Entity<Owner>().HasOne(x => x.Company)
                .WithOne(x => x.Owner).HasForeignKey<Owner>(x => x.CompanyId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=LearnEf;Trusted_Connection=True;",
                options => options.MaxBatchSize(666));
        }
    }
}
