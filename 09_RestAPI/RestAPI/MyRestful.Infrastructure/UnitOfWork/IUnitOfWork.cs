using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyRestful.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}
