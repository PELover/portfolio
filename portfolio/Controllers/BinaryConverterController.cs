using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System.Diagnostics;

namespace portfolio.Controllers
{
    public class BinaryConverterController : Controller
    {
        public IActionResult Index()
        {
            var bc = new BinaryConverter();
            return View(bc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BinaryConverter obj)
        {
            var bc = new BinaryConverter();
            bc.binoutput = bc.bintodemi(obj.bininput);
            bc.demioutput = bc.demitobin(obj.demiinput);
            return View(bc);
        }
    }
}
