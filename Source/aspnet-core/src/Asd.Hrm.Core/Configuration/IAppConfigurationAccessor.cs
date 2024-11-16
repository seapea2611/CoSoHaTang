using Microsoft.Extensions.Configuration;

namespace Asd.Hrm.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
