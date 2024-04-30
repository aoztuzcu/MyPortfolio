﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents;

public class _ExperienceComponentPartial : ViewComponent
{
    MyPortfolioContext _context = new MyPortfolioContext();
    public IViewComponentResult Invoke()
    {
        var values = _context.Experiences.ToList();
        return View(values);
    }
}
