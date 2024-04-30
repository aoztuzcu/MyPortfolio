using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            _context.Experiences.Remove(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }
    }
}
