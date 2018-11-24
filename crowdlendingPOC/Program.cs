using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace crowdlendingPOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
# if DEBUG            
            .CaptureStartupErrors(true)
            .UseSetting("detailedErrors", "true")
#endif
            .UseStartup<Startup>()
            .Build();
    }
}
