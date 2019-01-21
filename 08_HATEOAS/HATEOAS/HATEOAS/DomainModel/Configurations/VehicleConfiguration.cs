using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HATEOAS.DomainModel.Configurations
{
    public class VehicleConfiguration : EntityBaseConfiguration<Vehicle>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Vehicle> b)
        {
            b.Property(x => x.Model).IsRequired().HasMaxLength(50);
            b.Property(x => x.Owner).IsRequired().HasMaxLength(50);
        }
    }
}
