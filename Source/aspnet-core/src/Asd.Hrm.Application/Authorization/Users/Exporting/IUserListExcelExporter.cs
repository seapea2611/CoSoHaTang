using System.Collections.Generic;
using Asd.Hrm.Authorization.Users.Dto;
using Asd.Hrm.Dto;

namespace Asd.Hrm.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}