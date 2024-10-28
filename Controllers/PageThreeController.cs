using Microsoft.AspNetCore.Mvc;
using gproject.Models; // This is the namespace for your Rectangle class

namespace MyWebApp.Controllers
{
    public class PageThreeController : Controller
    {
        // GET method to display the form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST method to calculate the area
        [HttpPost]
        public IActionResult CalculateArea(double length, double width)
        {
            Rectangle rectangle = new Rectangle(length, width);
            double area = rectangle.CalculateArea();
            ViewBag.Result = $"The area of the rectangle is: {area}";
            return View("Index");
        }

        // POST method to calculate the perimeter
        [HttpPost]
        public IActionResult CalculatePerimeter(double length, double width)
        {
            Rectangle rectangle = new Rectangle(length, width);
            double perimeter = rectangle.CalculatePerimeter();
            ViewBag.Result = $"The perimeter of the rectangle is: {perimeter}";
            return View("Index");
        }
    }
}
