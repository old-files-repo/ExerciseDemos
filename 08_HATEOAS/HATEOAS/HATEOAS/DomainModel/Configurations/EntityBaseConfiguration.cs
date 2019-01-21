using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HATEOAS.DomainModel.Configurations
{
    public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.UpdateTime);
            builder.Property(x => x.CreateUser).IsRequired();
            builder.Property(x => x.UpdateUser);
            builder.Property(x => x.LastAction).IsRequired().HasMaxLength(200);

            ConfigureDerived(builder);
        }

        public abstract void ConfigureDerived(EntityTypeBuilder<T> b);
    }
}