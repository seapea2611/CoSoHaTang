using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Asd.Hrm.Authorization;

namespace Asd.Hrm
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(HrmApplicationSharedModule),
        typeof(HrmCoreModule)
        )]
    public class HrmApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmApplicationModule).GetAssembly());
        }
    }
}