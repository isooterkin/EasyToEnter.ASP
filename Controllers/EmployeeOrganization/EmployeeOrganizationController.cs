using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Controllers.EmployeeOrganization
{
    public class EmployeeOrganizationController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public EmployeeOrganizationController(EasyToEnterDbContext context) => _context = context;



        [HttpGet]
        [Authorized]
        //[EmployeeOrganization]
        public IActionResult Index()
        {
            return View();
        }
    }
}