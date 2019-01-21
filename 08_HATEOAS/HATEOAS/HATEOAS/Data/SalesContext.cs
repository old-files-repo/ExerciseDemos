using System.Threading;
using System.Threading.Tasks;
using HATEOAS.DomainModel;
using HATEOAS.DomainModel.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HATEOAS.Data
{
    public class SalesContext : DbContext, IUnitOfWork
    {
        public SalesContext(DbContextOptions<SalesContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        }

        public DbSet<Vehicle> Vehicles { get; set; }



        public bool Save()
        {
            return SaveChanges() >= 0;
        }

        public bool Save(bool acceptAllChangesOnSuccess)
        {
            return SaveChanges(acceptAllChangesOnSuccess) >= 0;
        }

        public async Task<bool> SaveAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken) >= 0;
        }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SaveChangesAsync(cancellationToken) >= 0;
        }
    }
}
