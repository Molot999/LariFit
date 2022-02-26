using System.ComponentModel.DataAnnotations.Schema;

namespace LariFit.Models.Trainings
{
    public class ExerciseSet
    {
        public ExerciseSet() { }
        public ExerciseSet(Exercise? exercise, bool isFinished, int setQuantity, int restTimeAfter)
        {
            Exercise = exercise;
            IsFinished = isFinished;
            SetQuantity = setQuantity;
            RestTimeAfter = restTimeAfter;
        }
        public int Id { get; set; }

        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set;}
        public Exercise? Exercise { get; set; }
        public bool IsFinished { get; set; }
        public int SetQuantity { get; set; }
        public int RestTimeAfter { get; set; }

    }
}
