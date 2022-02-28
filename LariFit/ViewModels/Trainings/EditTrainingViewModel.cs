using LariFit.Models.Trainings;

namespace LariFit.ViewModels.Trainings
{
    public class EditTrainingViewModel
    {
        public EditTrainingViewModel(){}

        public EditTrainingViewModel(int id, DateTime date, List<PerformingExercise> exercises)
        {
            Id = id;
            Date = date;
            Exercises = exercises;
        }

        public int Id { get; set; }
        public DateTime Date {get; set;}

        public List<PerformingExercise> Exercises { get; set; } = new List<PerformingExercise>();
    }
}
