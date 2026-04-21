using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IFlightService _flightService;

        public BookingController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IActionResult> CreateBooking(string id)
        {
            var value = await _flightService.GetFlightByIdAsync(id);
            ViewBag.flightNumber = value.FlightNumber;
            ViewBag.departureAirportCode = value.DepartureAirportCode;
            ViewBag.departureAirportName = value.DepartureAirportName;
            ViewBag.arrivaleAirportCode = value.ArrivalAirportCode;
            ViewBag.arrivaleAirportName = value.ArrivalAirportName;
            ViewBag.departureTime = value.DepartureTime;
            ViewBag.arrivalTime = value.ArrivalTime;
            return View(value);
        }

        public IActionResult BookingList()
        {
            return View();
        }
    }
}
