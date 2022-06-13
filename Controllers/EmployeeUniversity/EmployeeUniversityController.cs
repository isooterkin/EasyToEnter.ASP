using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Controllers.EmployeeUniversity
{
    public class EmployeeUniversityController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public EmployeeUniversityController(EasyToEnterDbContext context) => _context = context;



        [HttpGet]
        [Authorized]
        //[EmployeeUniversity]
        public IActionResult Index()
        {
            return View();
        }
    }
}