using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspTravlerz.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AngularTravlerz
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(env.ContentRootPath)
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
					.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
					.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("DefaultConnection");

			services
				.AddEntityFrameworkSqlite()
				.AddDbContext<TripDbContext>(options =>
				{
					//var connStringBuilder = new SqliteConnectionStringBuilder() { DataSource = "./trips.db" };
					options.UseSqlite(connectionString);
				});

			services.AddIdentity<ApplicationUser, IdentityRole>()
								.AddEntityFrameworkStores<TripDbContext>()
								.AddDefaultTokenProviders();

      services.AddAuthorization(configure =>
      {
        configure.AddPolicy("AdministratorsOnly", policy => policy.RequireRole("Administrator"));
        configure.AddPolicy("TripMaintainers", policy => policy.RequireAssertion(context =>
        {
          return context.User.IsInRole("Administrator") ||
              context.User.HasClaim(c => c.Type == ClaimTypes.Surname && c.Value == "Fritz");
        }));
        configure.AddPolicy("CanadianOrAdmin", policy => policy.RequireAssertion(context =>
        {
          return context.User.IsInRole("Administrator") ||
            context.User.HasClaim(claim => claim.Type == ClaimTypes.Country && claim.Value == "Canada");
        }));
        configure.AddPolicy("CanadianRequirement", policy => policy.AddRequirements(new CanadianRequirement()));
      });

      services.Configure<IdentityOptions>(options =>
      {

        options.Cookies.ApplicationCookie.AccessDeniedPath = "/Account/Forbidden";

      });

      services.AddScoped<TripRepository>();

			services.AddMvc()
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseIdentity();

			SampleData.InitializeData(app.ApplicationServices, loggerFactory);

			app.UseMvc(routes =>
			{
				routes.MapRoute(
									name: "default",
									template: "{controller=Home}/{action=Index}/{id?}");

				routes.MapSpaFallbackRoute(
									name: "spa-fallback",
									defaults: new { controller = "Home", action = "Index" });
			});
		}
	}

  public class CanadianRequirement : AuthorizationHandler<CanadianRequirement>, IAuthorizationRequirement
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanadianRequirement requirement)
    {

      if (context.User.IsInRole("Administrator"))
      {
        context.Succeed(requirement);
      }

      if (context.User.HasClaim(claim => claim.ValueType == ClaimTypes.Country && claim.Value == "Canada"))
      {
        context.Succeed(requirement);
      }

      return Task.CompletedTask;

    }
  }
}
