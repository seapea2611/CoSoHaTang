using Abp.AspNetCore.Mvc.Authorization;
using Asd.Hrm.Authorization;
using Asd.Hrm.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Asd.Hrm.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}