using System;

namespace Core.Rooms
{
    public class Room
    {
        public Room(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString() => Name;

        public override int GetHashCode() => HashCode.Combine(Name);

        public override bool Equals(object obj)
        {
            if (obj is null || GetType() != obj.GetType())
                return false;

            Room other = obj as Room;

            return Name.Equals(other.Name);
        }

    }
}