using LariFit.Models.Trainings;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LariFit.Models

{
    public class User : IdentityUser
    {
        public int? Calories { get; set; }
        public float? TargetWeight { get; set; }
        public int? Height { get; set; }
        public DateTime? BirthDate { get; set; }

        public List<Measurement> Measurements { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
