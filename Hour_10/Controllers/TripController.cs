using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Controllers
{
  public class TripController : BaseController
  {

    public TripController(ILoggerFactory loggerFactory) : base(loggerFactory)
    {

    }


    public IActionResult Index()
    {

      return View();

    }

    public IActionResult My() {

      var trips = new Models.Trip[] {
        new Models.Trip { Destination = "New York"},
        new Models.Trip { Destination = "Las Vegas"}
      };

      return Json(trips);

    }

  }
}
