using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IActionResult Index()
        {
            return View();
        }
        
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // Action สำหรับหน้าแรก
        [HttpGet]
        public IActionResult Index(string lang = "en") // กำหนดค่าเริ่มต้นเป็นภาษาอังกฤษ
        {
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, $"wwwroot/json/portoliohome_{lang}.json");
            string jsonContent = System.IO.File.ReadAllText(filePath);
            var translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
            ViewBag.Translations = translations;
            ViewBag.CurrentLanguage = lang;
            return View();
        }
    }
}
