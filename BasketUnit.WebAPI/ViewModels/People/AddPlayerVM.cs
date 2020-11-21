using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class AddPlayerVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Number { get; set; }
        public byte[] Avatar { get; set; }
        public int NationalityId { get; set; }
    }
}
