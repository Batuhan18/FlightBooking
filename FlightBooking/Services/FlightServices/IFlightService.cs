using FlightBooking.Dtos.FlightDtos;

namespace FlightBooking.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDto>> GetAllFlightAsync();
        Task<GetFlightByIdDto> GetFlightByIdAsync(string id);
        Task CreateFlightAsync(CreateFlightDto createFlightDto);
        Task UpdateFlightAsync(UpdateFlightDto updateFlightDto);
        Task DeleteFlightAsync(string id);
    }
}
