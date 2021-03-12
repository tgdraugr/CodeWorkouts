using System.Collections.Generic;

namespace Core.Bookings
{
    public interface IProvideBookings
    {
        IEnumerable<Booking> AllBookings();
    }
}
