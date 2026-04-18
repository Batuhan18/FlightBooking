using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.BookingViewComponents
{
    public class _BookingTagsViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
