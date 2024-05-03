using System;
using Microsoft.AspNetCore.Mvc;

namespace MvcMentor.Areas.Manage.Controllers
{
	[Area("manage")]
	public class DashboardController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

