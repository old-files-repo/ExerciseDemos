using System;
using System.Collections.Generic;
using System.Text;

namespace Learn.Domains
{
    public class Owner
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
    }
}
