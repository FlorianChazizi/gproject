using Microsoft.AspNetCore.Mvc;

namespace gproject.Controllers
{
    public class PageTwoController : Controller
    {
        // GET method to display the form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST method to handle form submission
        [HttpPost]
        public IActionResult Index(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                ViewBag.ReversedString = "Please enter a valid string.";
            }
            else
            {
                // Split the input string by spaces, reverse the array, and join it back together
                string[] words = input.Split(' ');
                string reversedString = string.Join(' ', words.Reverse());

                ViewBag.ReversedString = reversedString;
            }

            return View();
        }
    }
}
