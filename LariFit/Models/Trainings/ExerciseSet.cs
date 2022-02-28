using System.ComponentModel.DataAnnotations.Schema;

namespace LariFit.Models.Trainings
{
    public class ExerciseSet
    {
        public ExerciseSet() { }
        public ExerciseSet(PerformingExercise? exercise, int reps)
        {
            Exercise = exercise;
            Reps = Reps;
        }
        public int Id { get; set; }

        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set;}
        public PerformingExercise? Exercise { get; set; }
        public int? Reps { get; set; }
        public int? Weight { get; set; }

    }
}
