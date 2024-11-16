using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Asd.Hrm.Editions.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}