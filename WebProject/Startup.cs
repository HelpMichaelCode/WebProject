using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebProject.Database;

namespace WebProject
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// 2.2 which handles routing
			// UseMvc() is the way your application can say I want MVC to take a part in the 
			// request handling stage at "this" point. It's essentially a shortcut to an MVC specific middleware.
			app.UseMvc(routes =>
			{
				// MapRoute() maps the HTTP request to the specific controller file in the Controller folder
				// This is the defualt route meaning if you do /blog/post/123 -> it will still be valid
				// {controller = Blog(BlogController.cs file) / action = Post (which is the method inside the class) / {id?} (which is the parameters in the method)}
				// ? -> This indicates that it is a optional parameter to add to the url
				routes.MapRoute("Default", "{controller=Home}/{action=IMEI}/{id?}");
			});

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("{controller=Home}/{action=IMEI}/{id?}");
			//});

		}
	}
}
