using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuRestful.Core.Domains;
using MyRestful.Api.Controllers;

namespace MyRestful.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly MyContext _myContext;

        public CountryRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<Country> Get(int id)
        {
            return await _myContext.Countries.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _myContext.Countries.ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetByPage(QueryPage queryPage)
        {
            return await _myContext.Countries
                .OrderBy(x => queryPage.OrderBy)
                .Skip(queryPage.PageIndex * queryPage.PageIndex)
                .Take(queryPage.PageSize)
                .ToListAsync();
        }

        public async Task Add(Country country)
        {
            await _myContext.Countries.AddAsync(country);
        }
    }
}
