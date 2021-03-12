using Core.Bookings;

namespace Core
{
    public class BookingHandler
    {
        private readonly IBookRooms _bookRooms;

        public BookingHandler(IBookRooms bookRooms)
        {
            _bookRooms = bookRooms;
        }

        public void Handle(BookRoom command) => _bookRooms.BookRoom(command);
    }
}
