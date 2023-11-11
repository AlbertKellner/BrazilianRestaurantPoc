using Autofac;
using Playground.Application.Features.Order.Command.Create.Interface;
using Playground.Application.Features.Order.Command.Create.Repositories;

namespace Playground.Application.Shared.AutofacModules
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<PokemonApi>().As<IPokemonApi>();
            //builder.RegisterType<CreateOrderRepository>().As<ICreateOrderRepository>();

        }
    }
}
