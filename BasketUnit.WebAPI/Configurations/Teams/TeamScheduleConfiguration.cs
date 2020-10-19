using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class TeamScheduleConfiguration : IEntityTypeConfiguration<TeamSchedule>
    {
        public void Configure(EntityTypeBuilder<TeamSchedule> builder)
        {
            builder
                .HasMany(x => x.TeamScheduleActivities)
                .WithOne(y => y.TeamSchedule);
            builder
                .HasOne(x => x.Team)
                .WithOne(y => y.TeamSchedule);
        }
    }
}
