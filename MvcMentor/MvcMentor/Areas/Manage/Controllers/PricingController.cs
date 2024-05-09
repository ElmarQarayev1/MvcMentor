using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMentor.Data;
using MvcMentor.Models;

namespace MvcMentor.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
	public class PricingController:Controller
	{
        private readonly AppDbContext _context;

        public PricingController(AppDbContext context)
		{
            _context = context;
        }

        public  IActionResult Index()
        {
            var data = _context.Cards.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Features = _context.Features.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Card card)
        {
            ViewBag.Features = _context.Features.ToList();

            if (!ModelState.IsValid)
            {
                return View(card);
            }
     
            _context.Cards.Add(card);
         
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var card = _context.Cards.Include(x => x.CardFeatures).FirstOrDefault(x => x.Id == id);
            if (card==null)
            {
                return RedirectToAction("notfound", "error");
            }
            card.FeatureInts = card.CardFeatures.Select(x => x.FeatureId).ToList();

           
            return View(card);
        }
        [HttpPost]
        public IActionResult Edit(Card card)
        {
            Card? existsCard = _context.Cards.Include(x=>x.CardFeatures).FirstOrDefault(x=>x.Id==card.Id);
            if (card == null)
            {
                return RedirectToAction("notfound", "error");

            }
            foreach (var featureId in card.FeatureInts.FindAll(a => !existsCard.CardFeatures.Any(x => x.FeatureId == a)))
            {
                if (!_context.Features.Any(x => x.Id == featureId)) return RedirectToAction("notfound", "error");

                CardFeature cardfeature = new CardFeature
                {
                    FeatureId = featureId,
                    Card = card
                };

                existsCard.CardFeatures.Add(cardfeature);
            }
            existsCard.Name = card.Name;
            existsCard.Price = card.Price;
            existsCard.Button = card.Button;
            existsCard.ButtonUrl = card.ButtonUrl;
            existsCard.IsAdvance = card.IsAdvance;
            existsCard.IsFeature = card.IsFeature;
          
            _context.SaveChanges();


            return RedirectToAction("index");
        }


    }
}

