using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
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
            return View(passengers);
        }
    }
}
