using Abp.Application.Services;
using Abp.Configuration;
using Abp.Timing;
using Abp.Localization;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.Authorization;
using Asd.Hrm.Authorization.Users;
using Abp.Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Abp.Domain.Repositories;
using Asd.Hrm.Authorization.Users.Dto; // Make sure you have this using directive

namespace Asd.Hrm.My
{
    // Interface definition (only once and inside MyConfigurationAppService.cs)
    public interface IMyConfigurationAppService : IApplicationService
    {
        Task<MyConfigurationDto> GetMyConfiguration();
    }

    [AbpAuthorize]
    public class MyConfigurationAppService : ApplicationService, IMyConfigurationAppService
    {
        private readonly ISettingManager _settingManager;
        private readonly IClock _clock;
        private readonly ILocalizationManager _localizationManager;
        private readonly IAbpSession _abpSession;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;

        public MyConfigurationAppService(
            ISettingManager settingManager,
            IClock clock,
            ILocalizationManager localizationManager,
            IAbpSession abpSession,
            UserManager userManager,
            IRepository<User, long> userRepository)
        {
            _settingManager = settingManager;
            _clock = clock;
            _localizationManager = localizationManager;
            _abpSession = abpSession;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [DontWrapResult]
        public async Task<MyConfigurationDto> GetMyConfiguration()
        {
            // Example: Get some settings
            var recaptchaSiteKey = await _settingManager.GetSettingValueAsync("Recaptcha.SiteKey");
            var subscriptionExpireNotifyDayCount = await _settingManager.GetSettingValueAsync("App.TenantManagement.SubscriptionExpireNotifyDayCount");

            // Get the current user's ID (if needed)
            var currentUserId = _abpSession.UserId;

            // Get current user data using _userManager
            UserLoginInfoDto userLoginInfo = null;
            if (currentUserId != null)
            {
                //var user = await _userManager.GetUserByIdAsync(currentUserId.Value);
                var user = await _userRepository.FirstOrDefaultAsync(currentUserId.Value);
                userLoginInfo = ObjectMapper.Map<UserLoginInfoDto>(user);
            }

            // Get current language
            var currentLanguage = _localizationManager.CurrentLanguage;

            return new MyConfigurationDto
            {
                RecaptchaSiteKey = recaptchaSiteKey,
                SubscriptionExpireNotifyDayCount = int.Parse(subscriptionExpireNotifyDayCount),
                ClockProvider = _clock.Provider.ToString(), // Or whatever format you need
                CurrentLanguage = currentLanguage,
                CurrentUser = userLoginInfo
            };
        }
    }

    // DTO to hold the configuration data
    public class MyConfigurationDto
    {
        public string RecaptchaSiteKey { get; set; }
        public int SubscriptionExpireNotifyDayCount { get; set; }
        public string ClockProvider { get; set; }
        public object CurrentLanguage { get; set; }
        public UserLoginInfoDto CurrentUser { get; set; }
    }
}
