using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
