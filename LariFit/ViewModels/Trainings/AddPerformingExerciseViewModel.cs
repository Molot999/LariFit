using LariFit.Models.Trainings;

namespace LariFit.ViewModels.Trainings
{
    public class AddPerformingExerciseViewModel
    {
        public AddPerformingExerciseViewModel() {}
        public AddPerformingExerciseViewModel(string title, int? caloriesPerHour, int trainingId)
        {
            Title = title;
            CaloriesPerHour = caloriesPerHour;
            TrainingId = trainingId;
        }
        public AddPerformingExerciseViewModel(string title, int? caloriesPerHour, List<ExerciseSet> exerciseSets, int trainingId)
        {
            Title = title;
            CaloriesPerHour = caloriesPerHour;
            ExerciseSets = exerciseSets;
            TrainingId = trainingId;
        }
        public int TrainingId { get; set; }
        public string Title { get; set; }
        public int? CaloriesPerHour { get; set; }
        public List<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
    }
}
