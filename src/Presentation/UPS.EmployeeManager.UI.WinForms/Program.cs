using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Configuration;
using UPS.EmployeeManager.Services;
using UPS.EmployeeManager.Services.Implementation;

namespace UPS.EmployeeManager.UI.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string baseAddress = ConfigurationManager.AppSettings["API_BASE_ADDRESS"];

            // Create a service collection and configure the HttpClientFactory
            var services = new ServiceCollection();
            
            services.AddHttpClient("UPSTestEndpoint", client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
            });

            // Register your main form, services, and the HttpClientService
            services.AddSingleton<frmMain>();
            services.AddSingleton<IHttpClientService, HttpClientService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
           
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Add Serilog
            var serilogLogger = new LoggerConfiguration()
            .WriteTo.File("EmployeeManager.txt")
            .CreateLogger();
            services.AddLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Information);
                x.AddSerilog(logger: serilogLogger, dispose: true);
            });


            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<frmMain>();
                Application.Run(form);
            }
        }

        public static void GetConfigurationValue()
        {
            var baseAddy = ConfigurationManager.AppSettings["APIBaseAddress"];
            
            
        }
    }
}