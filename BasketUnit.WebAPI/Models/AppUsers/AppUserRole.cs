﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class AppUserRole : AuditEntity
    {
        public AppUserRole()
        {

        }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int AppRoleId { get; set; }
        public virtual AppRole AppRole { get; set; }
    }
}
