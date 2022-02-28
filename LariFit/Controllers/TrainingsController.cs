using LariFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LariFit.ViewModels.Measurements;
using Microsoft.AspNetCore.Authorization;
using LariFit.Models.Trainings;
using LariFit.ViewModels.Trainings;

namespace LariFit.Controllers
{
    [Authorize]
    public class TrainingsController : Controller
    {
        private readonly ApplicationContext db;
        private readonly UserManager<User> userManager;
        public TrainingsController(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            db = applicationContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult IndexTrainings()
        {
            string thisUserId = userManager.GetUserId(User);

            if (thisUserId != null)
            {
                List<Training> trainings = db.Trainings.Where(t => t.UserId == thisUserId).ToList();
                return View(trainings);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraining(DateTime date)
        {
            User user = await userManager.FindByIdAsync(userManager.GetUserId(User));

            if (user == null)
            {
                return NotFound();
            }
            
            Training training = new Training(user, date);

            db.Trainings.Add(training);
            db.SaveChanges();

            return RedirectToAction("IndexTrainings");

        }

        [HttpGet]
        public IActionResult EditTraining(int id)
        {
            Training training = db.Trainings.FirstOrDefault(t => t.Id == id);

            if (training == null)
            {
                return NotFound();
            }
                
            EditTrainingViewModel editTrainingViewModel = new EditTrainingViewModel(training.Id ,training.Date, training.Exercises);

            ViewBag.Exercises = db.Exercises.ToList();

            return View(editTrainingViewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> EditTraining(EditTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(userManager.GetUserId(User));

                if (user != null)
                {
                    Training training = db.Trainings.FirstOrDefault(t => t.Id == model.Id);

                    if(training == null)
                    {
                        return NotFound();
                    }

                    training.Date = model.Date;

                    db.SaveChanges();
                }
            }

            return RedirectToAction("EditTraining");
        }

        [HttpPost]
        public IActionResult DeleteTraining(int id)
        {
            Training training = db.Trainings.FirstOrDefault(t => t.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            db.Trainings.Remove(training);
            db.SaveChanges();

            return RedirectToAction("IndexTrainings");
        }

        [HttpGet]
        public IActionResult AddPerformingExercise(int exerciseId, int trainingId)
        {
            Exercise exercise = db.Exercises.FirstOrDefault(t => t.Id == exerciseId);

            AddPerformingExerciseViewModel addPerformingExerciseViewModel = new AddPerformingExerciseViewModel(exercise.Title, exercise.CaloriesPerHour, trainingId);

            return View(addPerformingExerciseViewModel);
        }

        [HttpPost]
        public IActionResult AddPerformingExercise(AddPerformingExerciseViewModel model)
        {
            return RedirectToAction("AddExercise");
        }
    }
}
