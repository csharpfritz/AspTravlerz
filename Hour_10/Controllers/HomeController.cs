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


		public HomeController(ILoggerFactory loggerFactory) : base(loggerFactory)
		{
			
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Faq()
		{

      var faq = new Tuple<string, string>(
        "Why did the chicken cross the road?",
        "To Get to the other side"
      );

      return View(faq);

		}




		public IActionResult Error()
		{
			return View();
		}

	}
}