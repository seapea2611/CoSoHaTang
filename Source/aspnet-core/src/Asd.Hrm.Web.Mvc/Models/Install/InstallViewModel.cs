using System.Collections.Generic;
using Abp.Localization;
using Asd.Hrm.Install.Dto;

namespace Asd.Hrm.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
