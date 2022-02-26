using LariFit.Models.Trainings;

namespace LariFit.ViewModels.Trainings
{
    public class EditTrainingViewModel
    {
        public EditTrainingViewModel(){}

        public EditTrainingViewModel(int id, DateTime date, List<Exercise> exercises)
        {
            Id = id;
            Date = date;
            Exercises = exercises;
        }

        public int Id { get; set; }
        public DateTime Date {get; set;}

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
