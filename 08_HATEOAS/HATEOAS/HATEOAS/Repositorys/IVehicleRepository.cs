using HATEOAS.Data;
using HATEOAS.DomainModel;

namespace HATEOAS.Repositorys
{
    public interface IVehicleRepository : IEntityBaseRepository<Vehicle>
    {
    }

    public class VehicleRepository : EntityBaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
