using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IBookingService _bookingService;

        public FlightsController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> FlightList()
        {
            var values = await _flightService.GetAllFlightAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDto createFlightDto)
        {
            await _flightService.CreateFlightAsync(createFlightDto);
            return RedirectToAction("FlightList");
        }

        public async Task<IActionResult> FlightDetail(string id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            var passengers = await _flightService.GetFlightDetailsWithPassengers(id);

            ViewBag.FlightNumber = flight?.FlightNumber ?? "_";
            ViewBag.AirlineCode = flight?.AirlineCode ?? "_";
            ViewBag.DepartureAirportCode = flight?.DepartureAirportCode ?? "_";
            ViewBag.ArrivalAirportCode = flight?.ArrivalAirportCode ?? "_";
            ViewBag.DepartureTime = flight?.DepartureTime;
            ViewBag.ArrivalTime = flight?.ArrivalTime;
            ViewBag.TotalSeats = flight?.TotalSeats ?? 0;
            ViewBag.Status = flight?.Status ?? "_";

            TempData["flightnumber"] = flight.FlightNumber;
            TempData["DepartureTime"] = flight.DepartureTime;
            TempData["ArrivalTime"] = flight.ArrivalTime;

            return View(passengers);
        }
    }
}
