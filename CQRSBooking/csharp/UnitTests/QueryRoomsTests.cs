using System;
using Core;
using Core.Bookings;
using Core.Rooms;
using Infrastructure;
using Moq;
using Xunit;

namespace UnitTests
{
    public class QueryRoomsTests
    {
        [Fact]
        public void FreeRooms_WithEmptyStore_ShouldBeEmpty()
        {
            var repository = new Mock<IProvideRooms>();
            var queries = new BookingRelatedQueries(repository.Object);

            var response = queries.FreeRooms(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            Assert.NotNull(response);
            Assert.Empty(response);
            repository.Verify(r => r.FreeRooms(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }

        [Fact]
        public void FreeRooms_WithRoomsAvailable_ShouldBeFilled()
        {
            var expectedRooms = new[]
            {
                new Room("Room1"),
                new Room("Room2")
            };

            var repository = new Mock<IProvideRooms>();
            repository
                .Setup(r => r.FreeRooms(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(expectedRooms);

            var queries = new BookingRelatedQueries(repository.Object);

            var response = queries.FreeRooms(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.Equal(expectedRooms, response);
            repository.Verify(r => r.FreeRooms(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }


        [Fact]
        public void FreeRooms_WithInMemoryAdapter_ShouldBeEmpty()
        {
            var now = DateTime.Now;

            var rooms = new[]
            {
                new Room("Room1")
            };

            var bookings = new[]
            {
                new Booking("Room1", now, now.AddDays(1))
            };

            var adapter = new InMemoryStore(rooms, bookings);
            var queries = new BookingRelatedQueries(adapter);

            Assert.Empty(queries.FreeRooms(now, now));
            Assert.Empty(queries.FreeRooms(now, now.AddDays(-1)));
            Assert.Empty(queries.FreeRooms(now, now.AddHours(20)));
        }

        [Fact]
        public void FreeRooms_WithInMemoryAdapter_ShouldBeFilled()
        {
            var now = DateTime.Now;

            var rooms = new[]
            {
                new Room("Room1"),
                new Room("Room2")
            };

            var bookings = new[]
            {
                new Booking("Room1", now, now.AddDays(1))
            };

            var adapter = new InMemoryStore(rooms, bookings);
            var queries = new BookingRelatedQueries(adapter);

            // Would require more testing... but, it's enough just for the experiment.
            Assert.NotEmpty(queries.FreeRooms(now, now.AddDays(1)));
            Assert.Equal(new[] { new Room("Room2") }, queries.FreeRooms(now, now.AddDays(1)));
            Assert.Equal(new[] { new Room("Room1"), new Room("Room2") }, queries.FreeRooms(now.AddDays(1), now.AddDays(2)));
        }
    }
}