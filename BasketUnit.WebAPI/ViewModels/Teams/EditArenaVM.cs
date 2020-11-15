using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class EditArenaVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Capacity { get; set; }
        public string Address { get; set; }
    }
}
