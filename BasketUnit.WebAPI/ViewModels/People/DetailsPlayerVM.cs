using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class DetailsPlayerVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int PositionId { get; set; }
        public byte[] Avatar { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public int TeamId { get; set; }
    }
}
