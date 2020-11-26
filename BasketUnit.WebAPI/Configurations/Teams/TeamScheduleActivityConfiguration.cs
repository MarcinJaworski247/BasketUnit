using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class TeamScheduleActivityConfiguration : IEntityTypeConfiguration<TeamScheduleActivity>
    {
        public void Configure(EntityTypeBuilder<TeamScheduleActivity> builder)
        {
            builder
                .HasOne(x => x.TeamSchedule)
                .WithMany(y => y.TeamScheduleActivities)
                .HasForeignKey(x => x.TeamScheduleId);
            builder
                .HasOne(x => x.Workout)
                .WithMany(y => y.TeamScheduleActivities)
                .HasForeignKey(x => x.WorkoutId);
            builder
                .HasOne(x => x.Game)
                .WithMany(y => y.TeamScheduleActivities);
        }
    }
}
