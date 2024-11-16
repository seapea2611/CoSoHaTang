using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asd.Hrm.MultiTenancy.HostDashboard.Dto;

namespace Asd.Hrm.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}