using System;
using System.Linq;
using Core;
using Core.Bookings;
using Infrastructure;
using Xunit;

namespace UnitTests
{
    public class BookRoomsTests
    {
        [Fact]
        public void BookRoom_WithEmptyStore_ShouldBeSuccessful()
        {
            var store = new InMemoryStore();
            Assert.Empty(store.AllBookings());

            var bus = new FakeBus();
            var handler = new BookingHandler(new BookingService(store, bus));
            bus.Subscribe<BookRoom>(handler.Handle);

            bus.Send(new BookRoom("Room1", DateTime.Now, DateTime.Now.AddDays(2)));

            var bookings = store.AllBookings();

            Assert.NotEmpty(bookings);
            Assert.Single(bookings);
            Assert.Equal("Room1", bookings.Single().RoomName);
        }
    }
}
