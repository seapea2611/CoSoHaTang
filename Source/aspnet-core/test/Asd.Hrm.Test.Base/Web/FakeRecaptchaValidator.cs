using System.Threading.Tasks;
using Asd.Hrm.Security.Recaptcha;

namespace Asd.Hrm.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
