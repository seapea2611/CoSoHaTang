using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm
{
    public class HrmCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmCoreSharedModule).GetAssembly());
        }
    }
}