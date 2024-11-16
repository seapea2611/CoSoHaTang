using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Asd.Hrm.Dto;

namespace Asd.Hrm.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
