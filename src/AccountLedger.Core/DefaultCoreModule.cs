using AccountLedger.Core.Interfaces;
using AccountLedger.Core.Services;
using Autofac;

namespace AccountLedger.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
