using Autofac;
using MediatR;
using Playground.Application.Features.Dish.Command.Create.Models;
using Playground.Application.Features.Dish.Command.Create.UseCase;

using System.Reflection;

namespace Playground.Application.Shared.AutofacModules
{
    public class HandlersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CreateDishCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(CreateDishUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));
        }
    }
}
