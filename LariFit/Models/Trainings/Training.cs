using LariFit.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LariFit.Models.Trainings
{
    public class Training
    {
        public Training() { }
        public Training(User? user, DateTime date)
        {
            User = user;
            Date = date;
        }
        public Training(User? user, List<Exercise> exercises)
        {
            User = user;
            Exercises = exercises;
        }

        public Training(User? user, List<Exercise> exercises, DateTime date) : this(user, exercises)
        {
            Date = date;
        }

        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User? User { get; set; }

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public DateTime Date { get; set; }
    }
}
