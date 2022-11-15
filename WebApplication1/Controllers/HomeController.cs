using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (TestContext context = new TestContext())
            {
                var question = context.Questions.ToList();
                ViewBag.data = question;

                return View();
            }           
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            return View();
        }
    }
}
