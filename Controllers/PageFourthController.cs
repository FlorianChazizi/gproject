using Microsoft.AspNetCore.Mvc;
using MyWebApp.Helpers;

namespace MyWebApp.Controllers
{
    public class PageFourController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
        return View("~/Views/PageFourth/Index.cshtml");  // Explicitly point to the view file
        }

        [HttpPost]
        public IActionResult CalculateCommonTime(string timeRange1, string timeRange2)
        {
            // Call the utility function to find the common time range
            string result = TimeRangeUtility.GetCommonTimeRange(timeRange1, timeRange2);

            // Pass the result to the view via ViewBag
            ViewBag.Result = result;

            return View("~/Views/PageFourth/Index.cshtml");  // Explicitly point to the view file
        }
    }
}
