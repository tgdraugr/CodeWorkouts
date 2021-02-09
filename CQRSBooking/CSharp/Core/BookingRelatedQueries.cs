using System;
using System.Collections.Generic;
using Core.Abstractions;
using Core.Rooms;

namespace Core
{
    public class BookingRelatedQueries : IFacade
    {
        private readonly IProvideRooms _roomsProvider;

        public BookingRelatedQueries(IProvideRooms roomsProvider)
        {
            _roomsProvider = roomsProvider;
        }

        public IEnumerable<Room> FreeRooms(DateTime arrival, DateTime departure) =>
            _roomsProvider.FreeRooms(arrival, departure);
    }
}
