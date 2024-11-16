using System.Collections.Generic;
using Asd.Hrm.Authorization.Users.Importing.Dto;
using Asd.Hrm.Dto;

namespace Asd.Hrm.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
