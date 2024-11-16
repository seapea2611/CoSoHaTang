using System.Threading.Tasks;

namespace Asd.Hrm.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}