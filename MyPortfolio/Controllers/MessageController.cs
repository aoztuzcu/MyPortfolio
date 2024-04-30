using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
	public class MessageController : Controller
	{
		MyPortfolioContext db = new MyPortfolioContext();
		public IActionResult Inbox()
		{
			var messages = db.Messages.ToList();
			return View(messages);
		}
		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = db.Messages.Find(id);
			value.IsRead = true;
			db.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = db.Messages.Find(id);
			value.IsRead = false;
			db.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult DeleteMessage(int id)
		{
			var value = db.Messages.Find(id);
			db.Messages.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult MessageDetail(int id)
		{
			var value = db.Messages.Find(id);
			return View(value);
		}
	}
}
