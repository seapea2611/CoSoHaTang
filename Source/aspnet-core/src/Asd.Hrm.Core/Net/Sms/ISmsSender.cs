using System.Threading.Tasks;

namespace Asd.Hrm.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}