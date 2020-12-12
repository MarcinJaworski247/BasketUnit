using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class DetailsCollegeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public byte[] Badge { get; set; }
    }
}
