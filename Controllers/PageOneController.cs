using Microsoft.AspNetCore.Mvc;

namespace gproject.Controllers
{
    public class PageOneController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int number1, int number2, int number3)
        {
            int sum = number1 + number2 + number3;
            if (sum % 2 == 0)
            {
                ViewBag.Message = $"The sum of the numbers is even: {sum}.";
            }
            else
            {
                ViewBag.Message = $"Try to put some even number in the sum bag.";
            }
            return View();
        }
    }
}