using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
