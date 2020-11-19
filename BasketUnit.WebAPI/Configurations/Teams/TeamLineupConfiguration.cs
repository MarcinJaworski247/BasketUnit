using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class TeamLineupConfiguration : IEntityTypeConfiguration<TeamLineup>
    {
        public void Configure(EntityTypeBuilder<TeamLineup> builder)
        {
            builder
                .HasOne(x => x.Team)
                .WithMany(y => y.TeamLineup);
            builder
                .HasOne(x => x.Player)
                .WithMany(y => y.TeamLineup);
        }
    }
}
