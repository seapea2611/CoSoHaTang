using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm
{
    [DependsOn(typeof(HrmCoreSharedModule))]
    public class HrmApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmApplicationSharedModule).GetAssembly());
        }
    }
}