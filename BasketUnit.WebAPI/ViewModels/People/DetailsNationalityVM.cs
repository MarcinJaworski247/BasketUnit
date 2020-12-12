using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class DetailsNationalityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Flag { get; set; }
    }
}
