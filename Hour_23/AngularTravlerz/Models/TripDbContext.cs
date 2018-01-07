using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Models
{
	public class TripDbContext : IdentityDbContext<ApplicationUser>
	{


		public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
		{
			Database.EnsureCreatedAsync().Wait();
		}

		public DbSet<Trip> Trips { get; set; }

		public DbSet<Segment> Segments { get; set; }

		public DbSet<Faq> FAQ { get; set; }

	}

}
