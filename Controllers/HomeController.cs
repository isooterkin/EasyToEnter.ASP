using EasyToEnter.ASP.Controllers.Authorization;
using EasyToEnter.ASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyToEnter.ASP.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [SessionCheck]
        public IActionResult Index() => View();



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}