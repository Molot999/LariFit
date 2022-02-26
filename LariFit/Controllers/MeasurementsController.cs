using LariFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LariFit.ViewModels.Measurements;
using Microsoft.AspNetCore.Authorization;

namespace LariFit.Controllers
{
    [Authorize]
    public class MeasurementsController : Controller
    {
        private readonly ApplicationContext db;
        private readonly UserManager<User> userManager;

        public MeasurementsController(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            db = applicationContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string thisUserId = userManager.GetUserId(User);

            User user = await userManager.FindByIdAsync(thisUserId);

            if(user == null)
            {
                return NotFound();
            }

            List<Measurement> measurements = db.Measurements.Where(m => m.UserId == thisUserId).ToList();

            ViewBag.TargetWeight = user.TargetWeight;

            return View(measurements);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Measurement measurement = db.Measurements.FirstOrDefault(m => m.Id == id);

            if (measurement == null)
            {
                return NotFound();
            }

            db.Measurements.Remove(measurement);
            db.SaveChanges();

                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMeasurementViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(userManager.GetUserId(User));

                if (user != null)
                {
                    Measurement measurement = new Measurement(user, model.MeasurementDate, model.Weight, model.Neck, model.Chest, model.Biceps, model.Waist, model.Hips, model.Thigh, model.Shin);

                    db.Measurements.Add(measurement);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
