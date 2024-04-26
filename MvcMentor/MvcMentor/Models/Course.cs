using System;
namespace MvcMentor.Models
{
	public class Course
	{
		public int Id { get; set; }

		public  int TrainerId { get; set; }

		public string Img { get; set; }

		public string Name { get; set; }

		public string Desc { get; set; }

		public double Price { get; set; }

		public string Category { get; set; }

		public Trainer Trainer { get; set; }

	}
}
