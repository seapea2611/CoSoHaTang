using System.Collections.Generic;
using Asd.Hrm.DashboardCustomization.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
