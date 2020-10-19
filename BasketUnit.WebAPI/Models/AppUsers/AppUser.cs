using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class AppUser : Person
    {
        public string Password { get; set; }
        public virtual List<AppUserRole> AppUserRoles { get; set; }
    }
}
