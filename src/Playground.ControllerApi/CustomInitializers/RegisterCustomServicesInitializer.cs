using BrazilianRestaurant.Application.Shared.ExternalServices;
using BrazilianRestaurant.Application.Shared.ExternalServices.Interfaces;
using Castle.Core.Smtp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Playground.Application.Features.Dish.Command.Create.Interface;
using Playground.Application.Features.Dish.Command.Create.Models;
using Playground.Application.Features.Dish.Command.Create.Repositories;
using Playground.Application.Features.Dish.Command.Create.UseCase;
using Playground.Application.Features.Dish.Command.Delete.Interface;
using Playground.Application.Features.Dish.Command.Delete.Models;
using Playground.Application.Features.Dish.Command.Delete.Repositories;
using Playground.Application.Features.Dish.Command.Delete.UseCase;
using Playground.Application.Features.Dish.Command.GetAll.Interface;
using Playground.Application.Features.Dish.Command.GetAll.Repositories;
using Playground.Application.Features.Dish.Command.GetById.Interface;
using Playground.Application.Features.Dish.Command.GetById.Repositories;
using Playground.Application.Features.Dish.Command.Update.Interface;
using Playground.Application.Features.Dish.Command.Update.Models;
using Playground.Application.Features.Dish.Command.Update.Repositories;
using Playground.Application.Features.Dish.Command.Update.UseCase;
using Playground.Application.Features.Dish.Query.GetAll.Models;
using Playground.Application.Features.Dish.Query.GetAll.UseCase;
using Playground.Application.Features.Dish.Query.GetById.Models;
using Playground.Application.Features.Dish.Query.GetById.UseCase;
using Playground.Application.Features.Order.Command.Create.Interface;
using Playground.Application.Features.Order.Command.Create.Models;
using Playground.Application.Features.Order.Command.Create.Repositories;
using Playground.Application.Features.Order.Command.Create.UseCase;
using Playground.Application.Features.Order.Command.Delete.Interface;
using Playground.Application.Features.Order.Command.Delete.Models;
using Playground.Application.Features.Order.Command.Delete.Repositories;
using Playground.Application.Features.Order.Command.Delete.UseCase;
using Playground.Application.Features.Order.Command.GetAll.Interface;
using Playground.Application.Features.Order.Command.GetAll.Repositories;
using Playground.Application.Features.Order.Command.GetById.Interface;
using Playground.Application.Features.Order.Command.GetById.Repositories;
using Playground.Application.Features.Order.Command.Update.Interface;
using Playground.Application.Features.Order.Command.Update.Models;
using Playground.Application.Features.Order.Command.Update.Repositories;
using Playground.Application.Features.Order.Command.Update.UseCase;
using Playground.Application.Features.Order.Query.GetAll.Models;
using Playground.Application.Features.Order.Query.GetAll.UseCase;
using Playground.Application.Features.Order.Query.GetById.Models;
using Playground.Application.Features.Order.Query.GetById.UseCase;
using Playground.Application.Features.TableReservation.Command.Create.Interface;
using Playground.Application.Features.TableReservation.Command.Create.Models;
using Playground.Application.Features.TableReservation.Command.Create.Repositories;
using Playground.Application.Features.TableReservation.Command.Create.UseCase;
using Playground.Application.Features.TableReservation.Command.Delete.Interface;
using Playground.Application.Features.TableReservation.Command.Delete.Models;
using Playground.Application.Features.TableReservation.Command.Delete.Repositories;
using Playground.Application.Features.TableReservation.Command.Delete.UseCase;
using Playground.Application.Features.TableReservation.Command.GetAll.Interface;
using Playground.Application.Features.TableReservation.Command.GetAll.Repositories;
using Playground.Application.Features.TableReservation.Command.GetById.Interface;
using Playground.Application.Features.TableReservation.Command.GetById.Repositories;
using Playground.Application.Features.TableReservation.Command.Update.Interface;
using Playground.Application.Features.TableReservation.Command.Update.Models;
using Playground.Application.Features.TableReservation.Command.Update.Repositories;
using Playground.Application.Features.TableReservation.Command.Update.UseCase;
using Playground.Application.Features.TableReservation.Query.GetAll.Models;
using Playground.Application.Features.TableReservation.Query.GetAll.UseCase;
using Playground.Application.Features.TableReservation.Query.GetById.Models;
using Playground.Application.Features.TableReservation.Query.GetById.UseCase;
using Playground.Application.Infrastructure.Filter;
using Playground.Application.Infrastructure.Handlers;
using Playground.Application.Shared.InMemoryDatabase;
using Playground.Configs;


namespace Microsoft.AspNetCore.Builder
{
    public static partial class RegisterCustomServicesInitializer
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            ConfigureMediatR(services);

            RegisterCustomDependencies(services);

            RegisterSwagger(services);

            RegisterAddApiVersioning(services);

            RegisterAddVersionedApiExplorer(services);

            ConfigureMediatR(services);

            services.AddMvc().AddControllersAsServices();

            services.AddTransient<CorrelationIdHandler>();

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(LogActionFilter));
                options.Filters.Add<HttpGlobalExceptionFilter>();

                AddCacheProfile(options, durationInSeconds: 1, ResponseCacheProfile.For1Second);
                AddCacheProfile(options, durationInSeconds: 5, ResponseCacheProfile.For5Seconds);
                AddCacheProfile(options, durationInSeconds: 15, ResponseCacheProfile.For15Seconds);
                AddCacheProfile(options, durationInSeconds: 120, ResponseCacheProfile.For2Minutes);
            });

            return services;
        }

        private static void AddCacheProfile(MvcOptions options, int durationInSeconds, string profileName)
        {
            options.CacheProfiles.Add(profileName, new CacheProfile()
            {
                Duration = durationInSeconds,
                Location = ResponseCacheLocation.Any,
                VaryByHeader = "CorrelationId"
            });
        }

        public static void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            RegisterRequestHandlers(services);
            
            RegisterInterfaces(services);
        }

        private static void RegisterRequestHandlers(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateDishCommand, CreateDishOutput>, CreateDishUseCaseHandler>();
            services.AddTransient<IRequestHandler<DeleteDishCommand, DeleteDishOutput>, DeleteDishUseCaseHandler>();
            services.AddTransient<IRequestHandler<UpdateDishCommand, UpdateDishOutput>, UpdateDishUseCaseHandler>();
            services.AddTransient<IRequestHandler<GetAllDishQuery, IEnumerable<GetAllDishOutput>>, GetAllDishUseCaseHandler>();
            services.AddTransient<IRequestHandler<GetByIdDishQuery, GetByIdDishOutput>, GetByIdDishUseCaseHandler>();

            services.AddTransient<IRequestHandler<CreateOrderCommand, CreateOrderOutput>, CreateOrderUseCaseHandler>();
            services.AddTransient<IRequestHandler<DeleteOrderCommand, DeleteOrderOutput>, DeleteOrderUseCaseHandler>();
            services.AddTransient<IRequestHandler<UpdateOrderCommand, UpdateOrderOutput>, UpdateOrderUseCaseHandler>();
            services.AddTransient<IRequestHandler<GetAllOrderQuery, IEnumerable<GetAllOrderOutput>>, GetAllOrderUseCaseHandler>();
            services.AddTransient<IRequestHandler<GetByIdOrderQuery, GetByIdOrderOutput>, GetByIdOrderUseCaseHandler>();

            services.AddTransient<IRequestHandler<CreateTableReservationCommand, CreateTableReservationOutput>, CreateTableReservationUseCaseHandler>();
            services.AddTransient<IRequestHandler<DeleteTableReservationCommand, DeleteTableReservationOutput>, DeleteTableReservationUseCaseHandler>();
            services.AddTransient<IRequestHandler<UpdateTableReservationCommand, UpdateTableReservationOutput>, UpdateTableReservationUseCaseHandler>();
            services.AddTransient<IRequestHandler<GetAllTableReservationQuery, IEnumerable<GetAllTableReservationOutput>>, GetAllTableReservationUseCaseHandler>();
            services.AddTransient<IRequestHandler<GetByIdTableReservationQuery, GetByIdTableReservationOutput>, GetByIdTableReservationUseCaseHandler>();
        }

        private static void RegisterInterfaces(IServiceCollection services)
        {
            services.AddScoped<ICreateDishRepository, CreateDishRepository>();
            services.AddScoped<IDeleteDishRepository, DeleteDishRepository>();
            services.AddScoped<IUpdateDishRepository, UpdateDishRepository>();
            services.AddScoped<IGetAllDishRepository, GetAllDishRepository>();
            services.AddScoped<IGetByIdDishRepository, GetByIdDishRepository>();

            services.AddScoped<ICreateOrderRepository, CreateOrderRepository>();
            services.AddScoped<IDeleteOrderRepository, DeleteOrderRepository>();
            services.AddScoped<IUpdateOrderRepository, UpdateOrderRepository>();
            services.AddScoped<IGetAllOrderRepository, GetAllOrderRepository>();
            services.AddScoped<IGetByIdOrderRepository, GetByIdOrderRepository>();

            services.AddScoped<ICreateTableReservationRepository, CreateTableReservationRepository>();
            services.AddScoped<IDeleteTableReservationRepository, DeleteTableReservationRepository>();
            services.AddScoped<IUpdateTableReservationRepository, UpdateTableReservationRepository>();
            services.AddScoped<IGetAllTableReservationRepository, GetAllTableReservationRepository>();
            services.AddScoped<IGetByIdTableReservationRepository, GetByIdTableReservationRepository>();

            services.AddTransient<INewEmailSender, NewEmailSender>();
        }

        private static void RegisterCustomDependencies(IServiceCollection services)
        {
            services.AddSingleton<DishInMemoryDatabase>(DishInMemoryDatabase.Instance);
            services.AddSingleton<OrderInMemoryDatabase>(OrderInMemoryDatabase.Instance);
            services.AddSingleton<TableReservationInMemoryDatabase>(TableReservationInMemoryDatabase.Instance);
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "BrazilianRestaurant.API - version 1.0",
                        Description = "Brazilian restaurant proof of concept"
                    });

                options.SwaggerDoc("v2",
                    new OpenApiInfo
                    {
                        Version = "v2",
                        Title = "BrazilianRestaurant.API - version 2.0",
                        Description = "Brazilian restaurant proof of concept"
                    });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.OperationFilter<AddCustomHeaderOnOpenApiFilter>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with 'Bearer ' into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        private static void RegisterAddApiVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            });
        }

        private static void RegisterAddVersionedApiExplorer(IServiceCollection services)
        {
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
