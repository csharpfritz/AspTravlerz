using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Models
{
	public class TripDbContext : DbContext
	{


		public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
		{
			Database.EnsureCreatedAsync().Wait();
		}

		public DbSet<Trip> Trips { get; set; }

		public DbSet<Segment> Segments { get; set; }

	}

}
