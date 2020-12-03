using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Elim5Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                  .CaptureStartupErrors(true)
                    .ConfigureLogging(logging =>
                    {
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                .UseStartup<Startup>()

                .ConfigureKestrel((context, options) =>
                {
                    options.AddServerHeader = false;
                    options.Limits.MaxRequestBodySize = 5 * 1024;
                })
                .UseIIS()
                .UseIISIntegration();
        }
    }
}
