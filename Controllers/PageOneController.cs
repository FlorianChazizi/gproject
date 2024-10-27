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

            int sum = 0;  // initialize sum

            if( number1 % 2 == 0 )
            {
                sum += number1;
            }

            if( number2 % 2 == 0 )
            {
                sum += number2;
            }

            if( number3 % 2 == 0 )
            {
                sum += number3;
            }

            ViewBag.Message = $"Το άθροισμα όλων τον άρτιων είναι: {sum}";


            return View();
        }
    }
}