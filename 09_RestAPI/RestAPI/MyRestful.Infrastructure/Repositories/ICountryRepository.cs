using System.Collections.Generic;
using System.Threading.Tasks;
using MuRestful.Core.Domains;
using MyRestful.Api.Controllers;

namespace MyRestful.Infrastructure.Repositories
{
    public interface ICountryRepository
    {
        Task Add(Country country);
        Task<Country> Get(int id);
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetByPage(QueryPage queryPage);
    }
}