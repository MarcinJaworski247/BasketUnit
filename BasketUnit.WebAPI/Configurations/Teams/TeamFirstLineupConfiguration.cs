using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class TeamFirstLineupConfiguration : IEntityTypeConfiguration<TeamFirstLineup>
    {
        public void Configure(EntityTypeBuilder<TeamFirstLineup> builder)
        {
            builder
                .HasOne(x => x.Team)
                .WithMany(y => y.TeamFirstLineup);
            builder
                .HasOne(x => x.Player)
                .WithMany(y => y.TeamFirstLineup);
        }
    }
}
