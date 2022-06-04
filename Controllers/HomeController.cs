using EasyToEnter.ASP.Controllers.Authorization;
using EasyToEnter.ASP.Models;
using EasyToEnter.ASP.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace EasyToEnter.ASP.Controllers
{
    public class HomeController : Controller
    {
        [SessionCheck]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //SessionCheckAttribute sessionCheckAttribute = (SessionCheckAttribute) MethodBase.GetCurrentMethod()?
            //    .GetCustomAttribute(typeof(SessionCheckAttribute), true)!;

            return View(); 
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}