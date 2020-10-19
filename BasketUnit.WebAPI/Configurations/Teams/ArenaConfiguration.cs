using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class ArenaConfiguration : IEntityTypeConfiguration<Arena>
    {
        public void Configure(EntityTypeBuilder<Arena> builder)
        {
            builder
                .HasOne(x => x.Team)
                .WithOne(y => y.Arena);
            builder
                .HasOne(x => x.Game)
                .WithOne(y => y.Arena);
        }
    }
}
