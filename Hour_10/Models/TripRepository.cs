using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Models
{
	public class TripRepository
	{

		public TripRepository(TripDbContext context)
		{
			Db = context;
		}

		public TripDbContext Db { get; }

		public IEnumerable<Trip> Get()
		{
			return Db.Trips.ToList();
		}

		public Trip GetById(int id)
		{

			var thisTrip = Db.Trips.Include(t => t.Segments).FirstOrDefault(t => t.ID == id);
			return thisTrip;
		}

		public int Add(Trip newTrip)
		{

			Db.Trips.Add(newTrip);
			Db.SaveChanges();

			return newTrip.ID;

		}

	}

}