using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LariFit.ViewModels.Account
{
    public class EditPersonalDataViewModel
    {
        public EditPersonalDataViewModel() { }
        public EditPersonalDataViewModel(string id, int? calories, float? targetWeight, int? height, DateTime? birthDate)
        {
            Id = id;
            Calories = calories;
            TargetWeight = targetWeight;
            Height = height;
            BirthDate = birthDate;
        }

        public string Id { get; set; }

        [Display(Name = "Калории")]
        public int? Calories { get; set; }

        [Display(Name = "Целевой вес")]
        public float? TargetWeight { get; set; }

        [Display(Name = "Рост")]
        public int? Height { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
