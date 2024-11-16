using System.Collections.Generic;
using Asd.Hrm.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Asd.Hrm.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
