using System;
using System.Collections.Generic;
using System.Linq;
using Core.Bookings;
using Core.Rooms;

namespace Infrastructure
{
    public class InMemoryStore : IProvideRooms, IProvideBookings, ISaveBookings
    {
        private readonly List<Room> _rooms;
        private readonly List<Booking> _bookings;

        public InMemoryStore() : this(new Room[] { }, new Booking[] { })
        { }

        public InMemoryStore(IEnumerable<Room> rooms, IEnumerable<Booking> bookings)
        {
            _rooms = rooms.ToList();
            _bookings = bookings.ToList();
        }

        public IEnumerable<Booking> AllBookings() => _bookings;

        public IEnumerable<Room> FreeRooms(DateTime arrival, DateTime departure)
        {
            if (ValidInterval(arrival, departure) is false)
                return new Room[] { };

            var bookedRooms = _bookings
                .Where(b => arrival >= b.Arrival && departure <= b.Departure)
                .Select(b => new Room(b.RoomName));

            return _rooms.Except(bookedRooms);
        }

        public void Save(Booking booking)
        {
            _bookings.Add(booking);
        }

        private bool ValidInterval(DateTime arrival, DateTime departure)
        {
            return arrival < departure &&
                (departure - arrival) >= TimeSpan.FromDays(1);
        }
    }
}
