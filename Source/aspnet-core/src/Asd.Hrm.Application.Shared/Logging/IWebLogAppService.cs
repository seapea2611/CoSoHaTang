using Abp.Application.Services;
using Asd.Hrm.Dto;
using Asd.Hrm.Logging.Dto;

namespace Asd.Hrm.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
