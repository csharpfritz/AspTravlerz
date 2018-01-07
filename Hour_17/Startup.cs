using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AspTravlerz.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.IO;

namespace AspTravlerz
{

	public class Startup
	{

		public Startup(IHostingEnvironment env)
		{
			// Setup configuration sources.

			var builder = new ConfigurationBuilder()
					.SetBasePath(env.ContentRootPath)
					.AddJsonFile("appsettings.json");

			Configuration = builder.Build();

		}


		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{

			var connectionString = Configuration.GetConnectionString("DefaultConnection");

			services
				.AddEntityFrameworkSqlite()
				.AddDbContext<TripDbContext>(options =>
				{
					var connStringBuilder = new SqliteConnectionStringBuilder() { DataSource = "./trips.db" };
					options.UseSqlite(connStringBuilder.ToString());
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
			loggerFactory.AddConsole();

			app.Use(async (ctx, next) =>
			{
				await next();
				var fileAndQuery = ctx.Request.Path.Value.Split('/').Last();
				var file = fileAndQuery.Substring(0, fileAndQuery.IndexOf("?") < 0 ? fileAndQuery.Length : fileAndQuery.IndexOf("?"));
				if (ctx.Response.StatusCode == 404 && !file.Contains("."))
				{
					ctx.Request.Path = "/Home/Index";
					await next();
				}
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			SampleData.InitializeData(app.ApplicationServices, loggerFactory);

			app.UseMvc(routes =>
			{
				//routes.MapRoute()
				routes.MapRoute("default", "{controller=Home}/{action=Index}/{id:int?}");
			});

			app.UseMvcWithDefaultRoute();


		}
	}
}
