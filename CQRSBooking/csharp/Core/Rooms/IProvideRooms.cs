using System;
using System.Collections.Generic;

namespace Core.Rooms
{
    public interface IProvideRooms
    {
        IEnumerable<Room> FreeRooms(DateTime arrival, DateTime departure);
    }
}