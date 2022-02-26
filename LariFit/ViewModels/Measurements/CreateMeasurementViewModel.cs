using System.ComponentModel.DataAnnotations;

namespace LariFit.ViewModels.Measurements
{
    public class CreateMeasurementViewModel
    {
        [Required(ErrorMessage = "Укажите дату")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime MeasurementDate { get; set; }

        [Display(Name = "Вес")]
        public float? Weight { get; set; }

        [Display(Name = "Шея")]
        public float? Neck { get; set; }

        [Display(Name = "Грудь")]
        public float? Chest { get; set; }

        [Display(Name = "Бицепс")]
        public float? Biceps { get; set; }

        [Display(Name = "Талия")]
        public float? Waist { get; set; }

        [Display(Name = "Бедра")]
        public float? Hips { get; set; }

        [Display(Name = "Бедро")]
        public float? Thigh { get; set; }

        [Display(Name = "Голень")]
        public float? Shin { get; set; }
    }
}
