using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Asd.Hrm.Authorization.Permissions.Dto;

namespace Asd.Hrm.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
