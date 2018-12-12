using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hackathonvoice.API.Utils;
using hackathonvoice.Database;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace hackathonvoice.API
{
    public class Program
    {
        /// <summary/>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);   

            var host = BuildWebHost(args);

            try
            {
                host.MigrateDatabase<DatabaseContext>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
  
            host.Run();
        }

        /// <summary>
        /// Построение хоста
        /// </summary>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}