using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class FirstLineupVM
    {
        public int? PointGuardId { get; set; }
        public int? ShootingGuardId { get; set; }
        public int? SmallForwardId { get; set; }
        public int? PowerForwardId { get; set; }
        public int? CenterId { get; set; }
    }
}
