using Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
                })
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog(SeriLogger.Configure);
        // substitui o logging padrão do .NET Core pelo Serilog, que é um framework de logging mais avançado e flexível.
        // Ele permite configurar o logging de forma mais detalhada, incluindo a possibilidade de enviar logs para diferentes destinos
        // (como arquivos, bancos de dados, etc.) e formatar os logs de maneira personalizada.

        //.ConfigureLogging((hostingContext, loggingbuilder) => {
        //    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //    loggingbuilder.AddConsole();
        //    loggingbuilder.AddDebug();
        //});
    }
}
