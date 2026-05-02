using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CheckInController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.flightNumber = TempData["flightnumber"];
            return View();
        }
    }
}
