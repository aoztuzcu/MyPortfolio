using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ToDoListController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = db.ToDoLists.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Status = false;
            db.ToDoLists.Add(toDoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteToDoList(int id)
        {
            var toDoList = db.ToDoLists.Find(id);
            db.ToDoLists.Remove(toDoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateToDoList(int id)
        {
            var toDoList = db.ToDoLists.Find(id);
            return View(toDoList);
        }
        [HttpPost]
        public IActionResult UpdateToDoList(ToDoList toDoList)
        {
            db.ToDoLists.Update(toDoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToDoListStatusTrue(int id)
        {
            var toDoList = db.ToDoLists.Find(id);
            toDoList.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToDoListStatusFalse(int id)
        {
            var toDoList = db.ToDoLists.Find(id);
            toDoList.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
