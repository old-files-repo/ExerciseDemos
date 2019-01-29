using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuRestful.Core.Domains;

namespace MyRestful.Infrastructure.Repositories
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.EnglishName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ChineseName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Abbreviation).IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.Cities).WithOne(x => x.Country).HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
