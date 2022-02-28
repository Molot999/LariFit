using Microsoft.AspNetCore.Mvc;
using LariFit.Models;
using LariFit.Models.Trainings;
using LariFit.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;

namespace LariFit.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        readonly ApplicationContext db;
        public AdminController(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        [HttpGet]
        public IActionResult IndexExercises()
        {
            Exercise[] exercises = db.Exercises.ToArray();

            return View(exercises);
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExercise(AddExerciseViewModel model)
        {
            if(ModelState.IsValid)
            {
                Exercise exercise = new Exercise(model.Title, model.CaloriesPerHour);

                db.Exercises.Add(exercise);
                db.SaveChanges();

                return RedirectToAction("IndexExercises");
            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteExercise(int id)
        {
            Exercise exercise = db.Exercises.FirstOrDefault(x => x.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercise);
            db.SaveChanges();

            return RedirectToAction("IndexExercises");
        }
    }
}
