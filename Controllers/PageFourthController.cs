using Microsoft.AspNetCore.Mvc;
using MyWebApp.Helpers;
using System;

namespace MyWebApp.Controllers
{
    public class PageFourthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateCommonTime(string timeRange1, string timeRange2)
        {
            try
            {
                // Parse the time ranges using TimeRange.ParseTimeRange
                var range1 = TimeRange.ParseTimeRange(timeRange1);
                var range2 = TimeRange.ParseTimeRange(timeRange2);

                // Get the overlapping time range result
                ViewBag.Result = TimeRange.GetOverlap(range1, range2);
            }
            catch (FormatException)
            {
                ViewBag.Result = "Invalid input format. Please use 'yyyy-MM-dd HH:mm - HH:mm'.";
            }
            catch (ArgumentException ex)
            {
                ViewBag.Result = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.Result = "An unexpected error occurred.";
            }

            return View("Index");
        }
    }
}
