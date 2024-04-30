using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
    public class StatisticController : Controller
    {
		MyPortfolioContext db = new MyPortfolioContext();
		public IActionResult Index()
        {
            ViewBag.v1=db.Skills.Count();
			ViewBag.v2 = db.Messages.Count();
			ViewBag.v3 = db.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = db.Messages.Where(x => x.IsRead == true).Count();
			return View();
        }
    }
}
