using Autofac;
using iPas.Infrastructure.EventBus.Abstractions;
using System.Reflection;

namespace PatientSearchService.API
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<PatientSearchRepository>()
                .As<IPatientSearchRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(PatientsDetailsMessageReceivedEventHandler).GetTypeInfo().Assembly)
                 .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
