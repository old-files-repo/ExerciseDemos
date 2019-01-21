using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreBackend.Api.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
            //Database.EnsureCreated();生成数据库及表,无法使用migrations修改，仅建库适应
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("xxxx connection string");
        //    base.OnConfiguring(optionsBuilder);
        //}//配置连接字符串
    }
}
