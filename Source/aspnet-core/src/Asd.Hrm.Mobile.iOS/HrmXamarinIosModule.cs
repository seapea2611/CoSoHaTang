using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm
{
    [DependsOn(typeof(HrmXamarinSharedModule))]
    public class HrmXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmXamarinIosModule).GetAssembly());
        }
    }
}