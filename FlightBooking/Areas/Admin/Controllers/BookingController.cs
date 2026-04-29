using FlightBooking.Dtos.BookingDtos;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IBookingService _bookingService;

        public BookingController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }


        [HttpGet]
        public async Task<IActionResult> CreateBooking(string id)
        {
            var value = await _flightService.GetFlightByIdAsync(id);
            ViewBag.id = id;
            ViewBag.flightNumber = value.FlightNumber;
            ViewBag.departureAirportCode = value.DepartureAirportCode;
            ViewBag.departureAirportName = value.DepartureAirportName;
            ViewBag.arrivaleAirportCode = value.ArrivalAirportCode;
            ViewBag.arrivaleAirportName = value.ArrivalAirportName;
            ViewBag.departureTime = value.DepartureTime;
            ViewBag.arrivalTime = value.ArrivalTime;
            ViewBag.airlaneCode = value.AirlineCode;
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("Index", "Bookings", new { area = "Admin" });
        }

        public IActionResult BookingList()
        {
            return View();
        }
    }
}
