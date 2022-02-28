namespace LariFit.Models.Trainings
{
    public class Exercise
    {
        public Exercise(string title, int? caloriesPerHour)
        {
            Title = title;
            CaloriesPerHour = caloriesPerHour;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? CaloriesPerHour { get; set; }

    }
}
