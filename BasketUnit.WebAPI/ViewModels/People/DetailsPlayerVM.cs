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
        public string Avatar { get; set; }
        public int PlayerNumber { get; set; }
        public string Team { get; set; }
        public int? TeamId { get; set; }
        public int NationalityId { get; set; }
        public string Nationality { get; set; }
        public int? CollegeId { get; set; }
        public string College { get; set; }
        public string CollegeBadge { get; set; }
        public string NationalityFlag { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string Injury { get; set; }
        public DateTime? InjuredTo { get; set; }
        public bool IsInjured { get; set; }
    }
}
