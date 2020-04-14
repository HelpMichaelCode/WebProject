using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebProject.Database;

namespace WebProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var dbConnection = DbConnection.Instance();
			
			dbConnection.DatabaseName = "MyDB";
			try
			{
				if (dbConnection.IsConnect())
				{
					Console.WriteLine("Connection Success!");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			//for(int i = 0; i < 10; i++)
			//{
			//	dbConnection.insertValidationMessage();
			//}
			CreateWebHostBuilder(args).Build().Run();

		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();

		
	}
}
