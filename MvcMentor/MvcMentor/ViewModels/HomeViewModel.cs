using System;
using MvcMentor.Models;

namespace MvcMentor.ViewModels
{
	public class HomeViewModel
	{
		public List<Course> Courses { get; set; }

		public List<Trainer> Trainers { get; set; }
	}
}

