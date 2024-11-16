using System.Collections.Generic;
using Asd.Hrm.Editions.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}