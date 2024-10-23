using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyWebApp.Controllers
{
    public class PageFifthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PerformTest()
        {
            // Create a list with 100,000 items
            List<string> namesList = new List<string>();
            for (int i = 0; i < 1000000; i++)
            {
                namesList.Add($"Name{i}");
            }
            namesList.Add("Bob");  // Add the target item "Bob" at the end of the list

            // Convert the list to a HashSet for faster lookup
            HashSet<string> namesSet = new HashSet<string>(namesList);

            // Measure lookup time for the List (linear search)
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool foundInList = LookupUsingList(namesList, "Bob");
            stopwatch.Stop();
            long listLookupTime = stopwatch.ElapsedMilliseconds;

            // Measure lookup time for the HashSet (constant time lookup)
            stopwatch.Restart();
            bool foundInSet = LookupUsingHashSet(namesSet, "Bob");
            stopwatch.Stop();
            long hashSetLookupTime = stopwatch.ElapsedMilliseconds;

            // Pass results to the view using ViewBag
            ViewBag.FoundInList = foundInList;
            ViewBag.ListLookupTime = listLookupTime;
            ViewBag.FoundInSet = foundInSet;
            ViewBag.HashSetLookupTime = hashSetLookupTime;

            return View("Index");
        }

        // Linear search method for List
        public static bool LookupUsingList(List<string> namesList, string name)
        {
            foreach (string item in namesList)
            {
                if (item == name)
                {
                    return true;
                }
            }
            return false;
        }

        // Constant time lookup method for HashSet
        public static bool LookupUsingHashSet(HashSet<string> namesSet, string name)
        {
            return namesSet.Contains(name);  // O(1) lookup
        }
    }
}
