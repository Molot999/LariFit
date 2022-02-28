using System.ComponentModel.DataAnnotations.Schema;

namespace LariFit.Models.Trainings
{
    public class PerformingExercise
    {
        public PerformingExercise() { }
        public PerformingExercise(Training? training, string title, List<ExerciseSet> exerciseSets, DateTime startTime, DateTime endTime)
        {
            Training = training;
            Title = title;
            ExerciseSets = exerciseSets;
            StartTime = startTime;
            EndTime = endTime;
        }
        public int Id { get; set; }

        [ForeignKey(nameof(Training))]
        public int TrainingId { get; set; }
        public Training? Training { get; set; }

        public string? Title { get; set; }
        public List<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int? EquipmentWeight { get; set; }
    }
}
