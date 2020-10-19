using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class FunctionalityAppRoleConfiguration : IEntityTypeConfiguration<FunctionalityAppRole>
    {
        public void Configure(EntityTypeBuilder<FunctionalityAppRole> builder)
        {
            builder
                .HasOne(x => x.Functionality)
                .WithMany(y => y.FunctionalityAppRoles);
            builder
                .HasOne(x => x.AppRole)
                .WithMany(y => y.FunctionalityAppRoles);
        }
    }
}
