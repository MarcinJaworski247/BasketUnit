using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasMany(x => x.TeamLineup)
                .WithOne(y => y.Team);
            builder
                .HasMany(x => x.TeamFirstLineup)
                .WithOne(y => y.Team);
            builder
                .HasMany(x => x.GameTeams)
                .WithOne(y => y.Team);
            builder
                .HasOne(x => x.Arena)
                .WithOne(y => y.Team);
            builder
                .HasOne(x => x.Coach)
                .WithOne(y => y.Team);
        }
    }
}
