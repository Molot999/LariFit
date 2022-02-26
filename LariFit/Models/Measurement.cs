using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LariFit.Models
{
    public class Measurement
    {
        public Measurement() { }
        public Measurement(User? user, DateTime measurementDate, float? weight, float? neck, float? chest, float? biceps, float? waist, float? hips, float? thigh, float? shin)
        {
            User = user;
            Date = measurementDate;
            Weight = weight;
            Neck = neck;
            Chest = chest;
            Biceps = biceps;
            Waist = waist;
            Hips = hips;
            Thigh = thigh;
            Shin = shin;
        }

        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User? User { get; set; }

        public DateTime Date { get; set; }

        public float? Weight { get; set; }

        public float? Neck { get; set; }
        public float? Chest { get; set; }
        public float? Biceps { get; set; }
        public float? Waist { get; set; }
        public float? Hips { get; set; }
        public float? Thigh { get; set; }
        public float? Shin { get; set; }
    }
}
