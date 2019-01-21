using System.Threading;
using System.Threading.Tasks;
using CoreApi.DataContext.Infrastructure;
using CoreApi.Infrastructure.Features;
using CoreApi.Models.Angular;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.DataContext.Core
{
    public class CoreContext : DbContext, IUnitOfWork
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema(AppSettings.DefaultSchema);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

        public DbSet<Client> Clients { get; set; }

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
