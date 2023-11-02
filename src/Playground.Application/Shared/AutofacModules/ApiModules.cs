using Autofac;

namespace Playground.Application.Shared.AutofacModules
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<PokemonApi>().As<IPokemonApi>();
        }
    }
}
