using Microsoft.AspNetCore.Antiforgery;

namespace Asd.Hrm.Web.Controllers
{
    public class AntiForgeryController : HrmControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
