using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspTravlerz.Controllers
{
  public abstract class BaseController : Controller {

    private Stopwatch _Timer;

    public BaseController(ILoggerFactory loggerFactory)
    {
      Logger = loggerFactory.CreateLogger("Controller");
    }

    protected ILogger Logger { get; private set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {

      _Timer = Stopwatch.StartNew();

      base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {

      context.HttpContext.Response.Headers.Add("X-ElapsedTime", new[] { _Timer.ElapsedMilliseconds.ToString() });

      Logger.LogInformation($"{context.HttpContext.Request.Path} - {_Timer.ElapsedMilliseconds}ms");

      base.OnActionExecuted(context);
    }

  }
}
