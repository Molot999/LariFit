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
        public Training(User? user, List<PerformingExercise> exercises)
        {
            User = user;
            Exercises = exercises;
        }

        public Training(User? user, List<PerformingExercise> exercises, DateTime date) : this(user, exercises)
        {
            Date = date;
        }

        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User? User { get; set; }

        public List<PerformingExercise> Exercises { get; set; } = new List<PerformingExercise>();

        public DateTime Date { get; set; }
    }
}
