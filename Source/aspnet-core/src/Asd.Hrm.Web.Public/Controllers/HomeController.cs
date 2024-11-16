using Microsoft.AspNetCore.Mvc;
using Asd.Hrm.Web.Controllers;

namespace Asd.Hrm.Web.Public.Controllers
{
    public class HomeController : HrmControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}