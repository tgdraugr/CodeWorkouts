using System;
using Core.Abstractions;

namespace Core.Bookings
{
    public class RoomBooked : IEvent
    {
        public RoomBooked(string roomName, DateTime arrival, DateTime departure)
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
