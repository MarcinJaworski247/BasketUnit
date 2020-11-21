using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class EditRefereeVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public int NationalityId { get; set; }
    }
}
