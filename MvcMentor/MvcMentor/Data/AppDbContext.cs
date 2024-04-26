using System;
using Microsoft.EntityFrameworkCore;
using MvcMentor.Models;

namespace MvcMentor.Data
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardFeature> CardFeatures { get; set; }
    }
}

