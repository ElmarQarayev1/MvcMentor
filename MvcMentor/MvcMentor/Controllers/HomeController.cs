using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMentor.Data;
using MvcMentor.ViewModels;

namespace MvcMentor.Controllers;

public class HomeController : Controller
{
    private AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;

    }
    public IActionResult Index()
    {
        HomeViewModel hv = new HomeViewModel()
        {
            Courses = _context.Courses.Include(x => x.Trainer).ToList(),
            Trainers =_context.Trainers.ToList()
         
        };
        return View(hv);
    }

}
