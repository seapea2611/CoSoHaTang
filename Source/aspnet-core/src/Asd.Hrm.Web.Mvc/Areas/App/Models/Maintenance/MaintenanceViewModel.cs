using System.Collections.Generic;
using Asd.Hrm.Caching.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}