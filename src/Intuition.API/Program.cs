using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Intuition.API
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Split(".")[0];

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();

        public static int Main(string[] args)
        {
            Console.Title = AppName;

            Log.Logger = CreateSerilogLogger(Configuration);

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", AppName);

                var host = CreateHostBuilder(args);

                Log.Information("Starting web host ({ApplicationContext})...", AppName);

                host.Run();

                return 0;
            }
            catch (Exception exc)
            {
                Log.Fatal(exc, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateHostBuilder(string[] args) 
        {
            return WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(false)
                //.UseKestrel()
                //.UseKestrel((context, options) => 
                //{
                //    options.Configure(Configuration.GetSection("Kestrel"))
                //    .Endpoint("HTTPS", listionOptions => 
                //    {
                //        listionOptions.ListenOptions.UseHttps(x509Certificate);
                //    });

                //})
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://*:8020")
                .UseSerilog()
                .Build();
        }

        private static ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            var seqServerUrl = configuration["Serilog:SeqServerUrl"];

            return new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .Enrich.WithProperty("ApplicationContext", "iPay.Identity")
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .WriteTo.Seq(String.IsNullOrWhiteSpace(seqServerUrl) ? "http://192.168.111.128:8091/" : seqServerUrl)
                                .ReadFrom.Configuration(configuration)
                                .CreateLogger();
        }
    }
}
