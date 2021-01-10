using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder
                .HasOne(x => x.WorkoutType)
                .WithMany(y => y.Workouts)
                .HasForeignKey(x => x.WorkoutTypeId);
            builder
                .HasMany(x => x.TeamScheduleActivities)
                .WithOne(y => y.Workout)
                .HasForeignKey(x => x.WorkoutId);
        }
    }
}
