using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Models
{
	public class SampleData
	{

		public static void InitializeData(IServiceProvider provider, ILoggerFactory loggerFactory)
		{

			var logger = loggerFactory.CreateLogger("InitializeData");

			using (var serviceScope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{

				var env = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();
				if (!env.IsDevelopment()) return;

				var db = serviceScope.ServiceProvider.GetService<TripRepository>();

        if (!db.Db.FAQ.Any())
        {
          db.Db.FAQ.Add(new Faq
          {
            Question = "Why did the chicken cross the road?",
            Answer = "To Get to the other side"
          });
          db.Db.SaveChanges();
        }
        else
        {
          logger.LogDebug("FAQ found, not creating sample FAQ");
        }

        // Exit now if we already have trips created
        if (db.Get().Any())
				{
					logger.LogDebug("Data found, not creating sample records");
					return;
				}

				var startDate = FirstFridayNextMonth(DateTime.Today);
				var endDate = startDate.AddDays(2);

				var newTrip = new Trip
				{
					Name = "Weekend in NYC",
					Destination = "New York",
					StartDate = startDate,
					EndDate = startDate.AddDays(3).AddMinutes(-1)
				};

				var trainDepart = new Segment
				{
					Name = "Amtrak Train PHL->NYP",
					StartDate = startDate.AddHours(17),
					EndDate = startDate.AddHours(19),
					DepartureAddress = "30th St. Station\n Philadelphia, PA",
					ArrivalAddress = "New York Penn Station\nNew York, NY",
					ReservationID = "123456",
					Trip = newTrip,
					Type = SegmentType.Train
				};
				newTrip.Segments.Add(trainDepart);

				var lodging = new Segment
				{
					Name = "Coolio Hotel at Times Square",
					StartDate = startDate.AddHours(19).AddMinutes(30),
					EndDate = endDate.AddHours(12),
					ArrivalAddress = "123456 Times Square, New York, NY",
					ReservationID = "ABCDE",
					Trip = newTrip,
					Type = SegmentType.Lodging
				};
				newTrip.Segments.Add(lodging);

				var trainReturn = new Segment
				{
					Name = "Amtrak Train NYP->PHL",
					StartDate = endDate.AddHours(15),
					EndDate = endDate.AddHours(17),
					DepartureAddress = "New York Penn Station\nNew York, NY",
					ArrivalAddress = "30th St. Station\n Philadelphia, PA",
					ReservationID = "654321",
					Trip = newTrip,
					Type = SegmentType.Train
				};
				newTrip.Segments.Add(trainReturn);

				db.Add(newTrip);

				var vegasTrip = new Trip
				{
					Name = "Week in Vegas",
					Destination = "Las Vegas",
					StartDate = DateTime.Now.Date.AddDays(21),
					EndDate = DateTime.Now.Date.AddDays(28)
				};
				db.Add(vegasTrip);

				db.Db.SaveChanges();


			}

		}

		private static DateTime FirstFridayNextMonth(DateTime dateToCheck)
		{

			var firstOfNextMonth = dateToCheck.AddMonths(1).AddDays(-1 * (dateToCheck.Day - 1));
			var daysUntilFriday = 5 - (int)firstOfNextMonth.DayOfWeek;

			return daysUntilFriday > 0 ? firstOfNextMonth.AddDays(daysUntilFriday) : firstOfNextMonth.AddDays(7 + daysUntilFriday);

		}

	}
}
