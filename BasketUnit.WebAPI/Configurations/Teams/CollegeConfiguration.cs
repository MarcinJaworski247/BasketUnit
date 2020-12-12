using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class CollegeConfiguration : IEntityTypeConfiguration<College>
    {
        public void Configure(EntityTypeBuilder<College>  builder)
        {
            builder
                .HasMany(x => x.Players)
                .WithOne(y => y.College)
                .HasForeignKey(y => y.CollegeId);
        }
    }
}
