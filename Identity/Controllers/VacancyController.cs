using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Authorize(Roles = "HR,Director")]
    public class VacancyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
