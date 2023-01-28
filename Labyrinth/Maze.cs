using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Maze
    {
        Dictionary<int, Room> rooms = null;

        public Maze()
        {
            this.rooms = new Dictionary<int, Room>();
        }
        public void AddRoom(Room room)
        {
            rooms.Add(room.RoomNumber, room);
        }
        public Room RoomNo(int number)
        {
            return rooms[number];
        }
    }

}
