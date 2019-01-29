using System.Collections;
using System.Collections.Generic;

namespace MuRestful.Core.Domains
{
    public class Country
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string Abbreviation { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
