using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class DetailsTeamVM
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Arena { get; set; }
        public string CoachFullName { get; set; }
        public byte[] Badge { get; set; }
    }
}
