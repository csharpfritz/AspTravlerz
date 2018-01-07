using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;

namespace asptravlerz {

  public class Startup {

    public Startup(IHostingEnvironment env)
    {

      var builder = new ConfigurationBuilder()  
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

      if (env.IsDevelopment()) builder.AddUserSecrets();

      builder.AddEnvironmentVariables();

      Configuration = builder.Build();

    }

    public IConfigurationRoot Configuration { get; private set; }



    public void ConfigureServices(IServiceCollection services) {

      services.AddMvc();

      services.AddDirectoryBrowser();

    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {

      loggerFactory.AddConsole(LogLevel.Information);

      //app.UseDeveloperExceptionPage();
      app.UseExceptionHandler("/error.html");

      app.UseDefaultFiles(new DefaultFilesOptions
      {
        DefaultFileNames = new List<string> { "index.html", "defaultFile.html" }
      });


      app.UseStaticFiles();

      app.UseStaticFiles(new StaticFileOptions()
      {
        FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), @"StuffOnDisk")
        ),
        RequestPath = new PathString("/StaticFiles")
      });

      app.UseStaticFiles(new StaticFileOptions()
      {
        FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(),
            @"wwwroot", "assets")),
        RequestPath = new PathString("/assets")
      });

      app.UseDirectoryBrowser(new DirectoryBrowserOptions()
      {
        FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(),
            @"wwwroot", "assets")),
        RequestPath = new PathString("/assets")

      });

      app.Run(context =>
      {
        throw new Exception("Not implemented yet");
      });

      app.UseMvc(routes =>
      {

        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}"
        );

      });


    }

  }


}