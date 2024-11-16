using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Asd.Hrm.EntityFrameworkCore;

namespace Asd.Hrm.HealthChecks
{
    public class HrmDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public HrmDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("HrmDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("HrmDbContext could not connect to database"));
        }
    }
}
