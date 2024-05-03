using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMentor.Models
{
	public class Card
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Price { get; set; }

		public string Button { get; set; }

		public string ButtonUrl { get; set; }

		public bool IsAdvance { get; set; }

		public bool IsFeature { get; set; }

		public List<CardFeature>? CardFeatures { get; set; }

		[NotMapped]
		public List<int>? FeatureInts { get; set; }= new List<int>();

	}

}

