using System.Collections.Generic;
using Asd.Hrm.DynamicEntityProperties.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
