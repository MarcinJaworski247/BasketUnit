using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasMany(x => x.GameReferees)
                .WithOne(y => y.Game);
            builder
                .HasMany(x => x.Stats)
                .WithOne(x => x.Game);
            builder
                .HasOne(x => x.Arena)
                .WithMany(y => y.Games);
        }
    }
}
