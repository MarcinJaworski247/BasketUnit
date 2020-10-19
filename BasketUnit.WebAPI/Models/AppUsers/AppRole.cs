using BasketUnit.WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class AppRole : AuditEntity
    {
        public AppRole()
        {
            FunctionalityAppRoles = new List<FunctionalityAppRole>();
            AppUserRoles = new List<AppUserRole>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public AppRoleType AppRoleType { get; set; }
        public virtual List<FunctionalityAppRole> FunctionalityAppRoles { get; set; }
        public virtual List<AppUserRole> AppUserRoles { get; set; }
    }
}
