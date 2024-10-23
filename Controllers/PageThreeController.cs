using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

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
         public IActionResult Calculate(double length, double width)
        {
            Rectangle rectangle = new Rectangle(length, width);
            double area = rectangle.CalculateArea();
            double perimeter = rectangle.CalculatePerimeter();

            // Store both results in ViewBag
            ViewBag.Area = area;
            ViewBag.Perimeter = perimeter;

            return View("Index");
        }
    }
}
