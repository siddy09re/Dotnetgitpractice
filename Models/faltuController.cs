using Microsoft.AspNetCore.Mvc;

namespace WebAppi.Models
{
    public class faltuController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Hey yooo");
            return View();
        }
    }
}
