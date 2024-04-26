using System;
using Microsoft.AspNetCore.Mvc;
using MvcMentor.Data;
using MvcMentor.ViewModels;

namespace MvcMentor.Controllers
{
	public class TrainersController:Controller
	{
        AppDbContext _context;
        public TrainersController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            TrainerViewModel hv = new TrainerViewModel()
            {
                Trainers = _context.Trainers.ToList()
            };
            return View(hv);
        }
    }
}

