using LariFit.Models.Trainings;

namespace LariFit.ViewModels.Trainings
{
    public class CreateExerciseViewModel
    {
        public string Title { get; set; }
        public List<ExerciseSet> ExerciseSets { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
