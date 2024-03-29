﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class EditCoachVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? ExperienceYears { get; set; }
        public DateTime BirthDate { get; set; }
        public int NationalityId { get; set; }
        public int? TeamId { get; set; }
    }
}
