﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class ListPlayersVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int NationalityId { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
        public byte[] Avatar { get; set; }
        public int? PlayerNumber { get; set; }
        public bool IsInjured { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? CollegeId { get; set; }
        public string College { get; set; }
    }
}
