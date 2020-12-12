using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Configurations
{
    public class PlayerInjuryConfiguration : IEntityTypeConfiguration<PlayerInjury>
    {
        public void Configure(EntityTypeBuilder<PlayerInjury> builder)
        {
            builder.HasOne(x => x.Player).WithMany(y => y.Injuries).HasForeignKey(x => x.PlayerId);
        }
    }
}
