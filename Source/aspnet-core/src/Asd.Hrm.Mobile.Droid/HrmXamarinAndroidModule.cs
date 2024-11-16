using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm
{
    [DependsOn(typeof(HrmXamarinSharedModule))]
    public class HrmXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmXamarinAndroidModule).GetAssembly());
        }
    }
}