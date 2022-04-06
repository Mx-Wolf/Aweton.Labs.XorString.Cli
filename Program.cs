// See https://aka.ms/new-console-template for more information
using Aweton.Labs.XorString.BusinessRules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aweton.Labs.XorString
{
  internal static class Program
  {
    public static void Main(string[] args)
    {
      IHost host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(ConfigureApp).ConfigureServices(ConfigureServices).Build();

      IXorStrings service = host.Services.GetRequiredService<IXorStrings>();
      IMiceRunInfo result = service.Run();
      Console.WriteLine("--> result is below");
      Console.WriteLine(result.UserId);
      Console.WriteLine(result.Token);

      void ConfigureApp(HostBuilderContext context, IConfigurationBuilder builder)
      {
        builder.AddCommandLine(args);
      }

      void ConfigureServices(HostBuilderContext context, IServiceCollection services)
      {
        services.AddXorStrings(context.Configuration);
      }
    }
  }
}