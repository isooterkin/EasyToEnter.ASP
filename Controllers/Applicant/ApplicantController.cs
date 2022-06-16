using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public ApplicantController(EasyToEnterDbContext context) => _context = context;



        public IActionResult Index() => RedirectToAction("LevelSelection");



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}