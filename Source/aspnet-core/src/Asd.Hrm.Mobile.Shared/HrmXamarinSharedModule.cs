using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm
{
    [DependsOn(typeof(HrmClientModule), typeof(AbpAutoMapperModule))]
    public class HrmXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmXamarinSharedModule).GetAssembly());
        }
    }
}