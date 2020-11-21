using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasMany(x => x.Stats)
                .WithOne(y => y.Player);

            builder
                .HasMany(x => x.TeamLineup)
                .WithOne(y => y.Player);

            builder
                .HasMany(x => x.TeamFirstLineup)
                .WithOne(y => y.Player);
        }
    }
}
