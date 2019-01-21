using System;
using System.Collections.Generic;
using System.Linq;
using Learn.Data;
using Learn.Domains;
using Microsoft.EntityFrameworkCore;

namespace Learn.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!!!");

            //Insert();
            //InsertMultiple();
            FunctionsLike();

            Console.ReadKey();
        }

        private static void RawSql()
        {
            var searchTerm = "%so%";
            using (var context = new MyContext())
            {
                var results = context.Database.ExecuteSqlCommand($"DELETE FROM Companies WHERE NAME LIKE {searchTerm}");
                Console.WriteLine(results);
            }
        }

        private static void FunctionsLike()
        {
            using (var context = new MyContext())
            {
                var likes = context.Companies.Where(x=>EF.Functions.Like(x.Name,"%y%")).ToList();
                likes.ForEach(Console.WriteLine);
            }
        }

        private static void SimpleQuery()
        {
            using (var context = new MyContext())
            {
                var companies = context.Companies.ToList();
                companies.ForEach(Console.WriteLine);
            }
        }

        private static void Insert()
        {
            var company = new Company
            {
                Name = "yu",
                StartDate = new DateTime(),
                Departments = new List<Department>()
                {
                    new Department
                    {
                        Name=""
                    }
                }
            };
            using (var context = new MyContext())
            {
                context.Companies.Add(company);

                context.SaveChanges();
            }
        }

        private static void InsertMultiple()
        {
            var company = new Company
            {
                Name = "yu",
                StartDate = new DateTime()
            };

            var city = new City
            {
                Name = "yu",
            };

            using (var context = new MyContext())
            {
                context.Companies.AddRange(company, company);
                context.Companies.AddRange(new List<Company> { company, company });

                context.AddRange(city, company);

                context.SaveChanges();
            }
        }
    }
}
