using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspTravlerz.Models;

namespace AspTravlerz.Controllers
{
	public class HomeController : BaseController
	{
		private readonly TripDbContext _TripDbContext;

		public HomeController(ILoggerFactory loggerFactory, TripDbContext tripDbContext) : base(loggerFactory)
		{
			_TripDbContext = tripDbContext;
		}

		public async Task<IActionResult> Index()
		{

			var weather = await Weather.WeatherProxy.GetConditions("Philadelphia");

			return View(weather);
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Faq()
		{
			return View("FaqList",_TripDbContext.FAQ.ToList());
		}




		public IActionResult Error()
		{
			return View();
		}

	}
}