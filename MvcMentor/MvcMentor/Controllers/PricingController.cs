using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMentor.Data;
using MvcMentor.ViewModels;

namespace MvcMentor.Controllers
{
	public class PricingController:Controller
	{
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
		{
            _context = context;
        }

        public IActionResult Index()
        {
            PricingViewModel pm = new PricingViewModel()
            {
                Cards = _context.Cards.Include(x=>x.CardFeatures).ToList(),
                Features= _context.Features.ToList()
            };
            return View(pm);
        }
	}
}

