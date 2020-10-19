using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class WorkoutTypeConfiguration : IEntityTypeConfiguration<WorkoutType>
    {
        public void Configure(EntityTypeBuilder<WorkoutType> builder)
        {
            builder
                .HasMany(x => x.Workouts)
                .WithOne(y => y.WorkoutType);
        }
    }
}
