﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Asd.Hrm.Configuration.Dto;

namespace Asd.Hrm.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();
    }
}
