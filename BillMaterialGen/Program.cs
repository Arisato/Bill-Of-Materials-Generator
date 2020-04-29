using System.IO;
using BillMaterialGen.Configuration;
using BillMaterialGen.Configuration.Interfaces;
using BillMaterialGen.Generators;
using BillMaterialGen.Generators.Interfaces;
using BillMaterialGen.Logger;
using BillMaterialGen.Logger.Interfaces;
using BillMaterialGen.Readers;
using BillMaterialGen.Readers.Interfaces;
using BillMaterialGen.Validation;
using BillMaterialGen.Validation.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace BillMaterialGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .Build();

            var settings = new Settings();
            config.Bind(settings);

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<ISettings>(settings)
                .AddSingleton((ILogger)new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"../../../Logs/log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Debug)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger())
                .AddSingleton<IErrorLogger, ErrorLogger>()
                .AddSingleton<IInputValidator, InputValidator>()
                .AddSingleton<ILegacyBuilderMaterialGenerator, LegacyBuilderMaterialGenerator>()
                .AddSingleton<IConsoleInputRetriever, ConsoleInputRetriever>()
                .AddSingleton<IConsoleReader, ConsoleReader>()
                .AddSingleton<IDatabaseReader, DatabaseReader>()
                .AddSingleton<Startup>()
                .BuildServiceProvider();

            serviceProvider.GetService<Startup>().Run();
        }
    }
}
