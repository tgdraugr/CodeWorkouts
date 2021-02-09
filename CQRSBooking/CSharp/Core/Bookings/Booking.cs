using System;

namespace Core.Bookings
{
    public class Booking
    {
        public Booking(string roomName, DateTime arrival, DateTime departure)
        {
            RoomName = roomName;
            Arrival = arrival;
            Departure = departure;
        }

        public string RoomName { get; }

        public DateTime Arrival { get; }

        public DateTime Departure { get; }
    }
}
