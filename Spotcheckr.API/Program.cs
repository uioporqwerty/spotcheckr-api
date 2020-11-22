using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spotcheckr.API.Data;

namespace Spotcheckr.API
{
    public class Program
    {
	    public static Task Main(string[] args)
	    {
		    var host = CreateWebHostBuilder(args).Build();

			CreateDatabase(host);

		    return host.StartAsync();
	    } 

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void CreateDatabase(IWebHost host)
        {
			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;

			try
			{
				var context = services.GetRequiredService<SpotcheckrCoreContext>();
				DatabaseInitializer.Initialize(context);
			}
			catch (Exception ex)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, "An error occurred creating the Spotcheckr Core database.");
			}
        }
    }
}
