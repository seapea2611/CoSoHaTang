using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Asd.Hrm.Configure;
using Asd.Hrm.Startup;
using Asd.Hrm.Test.Base;

namespace Asd.Hrm.GraphQL.Tests
{
    [DependsOn(
        typeof(HrmGraphQLModule),
        typeof(HrmTestBaseModule))]
    public class HrmGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmGraphQLTestModule).GetAssembly());
        }
    }
}