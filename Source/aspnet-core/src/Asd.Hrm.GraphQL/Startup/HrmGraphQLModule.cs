using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm.Startup
{
    [DependsOn(typeof(HrmCoreModule))]
    public class HrmGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}