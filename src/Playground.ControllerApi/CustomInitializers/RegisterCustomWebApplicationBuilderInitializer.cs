using Autofac;
using Playground.Application.Shared.AutofacModules;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Playground.Application.Shared;
using Serilog.Events;

namespace Microsoft.AspNetCore.Builder
{
    public static partial class RegisterCustomWebApplicationBuilderInitializer
    {
        public static WebApplicationBuilder RegisterCustomWebApplicationBuilder(this WebApplicationBuilder builder)
        {
            SerilogConfig(builder, builder.Environment);

            ServiceProviderFactory(builder);

            LoadEnvironmentOptions(builder);

            EnableCors(builder);

            return builder;
        }

        private static void EnableCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
        }

        private static void ServiceProviderFactory(WebApplicationBuilder builder) =>
            builder.Host.UseServiceProviderFactory<ContainerBuilder>(new AutofacServiceProviderFactory())
                .ConfigureContainer((Action<ContainerBuilder>)(builder =>
                {
                    //builder.RegisterModule(new HandlersModule());
                    builder.RegisterModule(new ApiModule());
                }));

        private static void LoadEnvironmentOptions(WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
        }

        private static void SerilogConfig(WebApplicationBuilder builder, IWebHostEnvironment environment)
        {
            const string outputTemplateWithoutProperties = "[{Timestamp:HH:mm:ss.fff} {Level:u3}] [{CorrelationId}] [{ExecutionTime}] [{ExecutionTimeSinceLastLog}] {Message:lj} {NewLine}{Exception}";
            //const string outputTemplateWithoutProperties = "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Message:lj} {NewLine}{Exception}";
            const string outputTemplateWithProperties = "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Message:lj} {NewLine}{Exception}{Properties:j}{NewLine}{NewLine}";

            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration) // Reads settings from appsettings.json
                .Enrich.FromLogContext()
                .Enrich.With<LogEnricher>()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                //.WriteTo.Console(outputTemplate: outputTemplateWithoutProperties);
                .WriteTo.Async(a => a.Console(outputTemplate: outputTemplateWithoutProperties));

            //if (environment.IsDevelopment())
            //{
            //    loggerConfiguration.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, outputTemplate: outputTemplateWithProperties);
            //}

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}
