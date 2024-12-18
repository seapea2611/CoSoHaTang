﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Asd.Hrm.Editions.Dto;

namespace Asd.Hrm.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}