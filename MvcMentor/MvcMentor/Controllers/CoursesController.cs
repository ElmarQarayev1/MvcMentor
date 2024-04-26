using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMentor.Data;
using MvcMentor.Models;
using MvcMentor.ViewModels;

namespace MvcMentor.Controllers
{
	public class CoursesController:Controller
	{

        private AppDbContext _context;
        public CoursesController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            CourseViewModel hv = new CourseViewModel()
            {
                Courses = _context.Courses.Include(x => x.Trainer).ToList(),

            };
            return View(hv);
        }
    }
}

