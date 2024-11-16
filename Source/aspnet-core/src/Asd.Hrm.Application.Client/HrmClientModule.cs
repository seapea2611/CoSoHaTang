using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Asd.Hrm
{
    public class HrmClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HrmClientModule).GetAssembly());
        }
    }
}
