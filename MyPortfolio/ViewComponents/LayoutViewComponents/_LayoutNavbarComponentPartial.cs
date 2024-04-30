using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents;

public class _LayoutNavbarComponentPartial:ViewComponent
{
    MyPortfolioContext db = new MyPortfolioContext();
    public IViewComponentResult Invoke()
	{
        ViewBag.toDoListCount = db.ToDoLists.Where(x=>x.Status==false).Count();
        var values = db.ToDoLists.Where(x => x.Status == false).ToList();
        return View(values);
	}
}
