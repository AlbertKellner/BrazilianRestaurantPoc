﻿using Autofac;
using MediatR;
using Playground.Application.Features.Dish.Command.Create.Models;
using Playground.Application.Features.Dish.Command.Create.UseCase;
//using Playground.Application.Features.ToDoItems.Command.Create.Models;
//using Playground.Application.Features.ToDoItems.Command.Create.UseCase;
//using Playground.Application.Features.ToDoItems.Command.Delete.Models;
//using Playground.Application.Features.ToDoItems.Command.Delete.UseCase;
//using Playground.Application.Features.ToDoItems.Command.PatchIsCompleted.Models;
//using Playground.Application.Features.ToDoItems.Command.PatchIsCompleted.UseCase;
//using Playground.Application.Features.ToDoItems.Command.PatchTaskName.Models;
//using Playground.Application.Features.ToDoItems.Command.PatchTaskName.UseCase;
//using Playground.Application.Features.ToDoItems.Command.Update.Models;
//using Playground.Application.Features.ToDoItems.Command.Update.UseCase;
//using Playground.Application.Features.ToDoItems.Query.GetAll.Models;
//using Playground.Application.Features.ToDoItems.Query.GetAll.UseCase;
//using Playground.Application.Features.ToDoItems.Query.GetById.Models;
//using Playground.Application.Features.ToDoItems.Query.GetById.UseCase;
using System.Reflection;

namespace Playground.Application.Shared.AutofacModules
{
    public class HandlersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(typeof(CreateToDoItemCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(CreateToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            //builder.RegisterAssemblyTypes(typeof(GetByIdToDoItemQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(GetByIdToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            //builder.RegisterAssemblyTypes(typeof(GetAllToDoItemQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(GetAllToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            //builder.RegisterAssemblyTypes(typeof(UpdateToDoItemCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(UpdateToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            //builder.RegisterAssemblyTypes(typeof(DeleteToDoItemCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(DeleteToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            //builder.RegisterAssemblyTypes(typeof(PatchTaskNameToDoItemCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(PatchTaskNameToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            //builder.RegisterAssemblyTypes(typeof(IsCompletedToDoItemCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(IsCompletedToDoItemUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));

            builder.RegisterAssemblyTypes(typeof(CreateDishCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(CreateDishUseCaseHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<>));
        }
    }
}
