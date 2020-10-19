using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{ 
    public class GameTeamsConfiguration : IEntityTypeConfiguration<GameTeams>
    {
        public void Configure(EntityTypeBuilder<GameTeams> builder)
        {
            builder
                .HasOne(x => x.Game)
                .WithMany(y => y.GameTeams);
            builder
                .HasOne(x => x.Team)
                .WithMany(y => y.GameTeams);
        }
    }
}
