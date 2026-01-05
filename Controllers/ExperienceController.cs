using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext portfolioContext= new MyPortfolioContext();
        public IActionResult ExperienceList()
        {
            var values=portfolioContext.Experiences.ToList();
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
            portfolioContext.Experiences.Add(experience);
            portfolioContext.SaveChanges();
            return RedirectToAction("ExperienceList"); 
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = portfolioContext.Experiences.Find(id);
            portfolioContext.Experiences.Remove(values);
            portfolioContext.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var values = portfolioContext.Experiences.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            portfolioContext.Experiences.Update(experience);
            portfolioContext.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

    }
}
