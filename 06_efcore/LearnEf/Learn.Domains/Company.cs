using System;
using System.Collections.Generic;

namespace Learn.Domains
{
    public class Company
    {
        public Company()
        {
            Departments = new List<Department>();
            CompanyCities = new List<CompanyCity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public List<Department> Departments { get; set; }
        public List<CompanyCity> CompanyCities { get; set; }
        public Owner Owner { get; set; }

        public override string ToString()
        {
            return $"{Name}({Id}),成立于：{StartDate:yyyy-MM-dd}";
        }
    }
}