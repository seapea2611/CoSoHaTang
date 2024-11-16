using System.Threading.Tasks;
using Asd.Hrm.Sessions.Dto;

namespace Asd.Hrm.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
