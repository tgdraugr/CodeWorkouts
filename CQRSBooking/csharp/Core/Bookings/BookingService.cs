using Core.Abstractions;

namespace Core.Bookings
{
    public class BookingService : IBookRooms
    {
        private readonly ISaveBookings _bookings;
        private readonly IEventPublisher _eventsPublisher;

        public BookingService(ISaveBookings bookings, IEventPublisher eventPublisher)
        {
            _bookings = bookings;
            _eventsPublisher = eventPublisher;
        }

        public void BookRoom(BookRoom command)
        {
            var booking = new Booking(command.RoomName, command.Arrival, command.Departure);
            _bookings.Save(booking);

            _eventsPublisher.Publish(new RoomBooked(booking.RoomName, booking.Arrival, booking.Departure));
        }
    }
}
