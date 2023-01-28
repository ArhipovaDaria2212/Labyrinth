using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class MazeGame
    {
        public Maze aMaze = null;
        public Maze CreateMaze()
        {
            Maze aMaze = new Maze();
            Room r1 = new Room(1);
            Room r2 = new Room(2);
            Door theDoor = new Door(r1, r2);
            aMaze.AddRoom(r1);
            aMaze.AddRoom(r2);
            r1.SetSide(Direction.North, new Wall());
            r1.SetSide(Direction.East, theDoor);
            r1.SetSide(Direction.South, new Wall());
            r1.SetSide(Direction.West, new Wall());
            r2.SetSide(Direction.North, new Wall());
            r2.SetSide(Direction.East, new Wall());
            r2.SetSide(Direction.South, new Wall());
            r2.SetSide(Direction.West, theDoor);
            return aMaze;
        }

        public void start()
        {
            
            Room current = aMaze.RoomNo(1);
            while (true)
            {
                var Ch = Console.ReadKey(false).Key;

                Direction direct;
                switch (Ch)
                {
                    case ConsoleKey.UpArrow: Console.Write("^ "); direct = Direction.North; break;
                    case ConsoleKey.DownArrow: Console.Write("v "); direct = Direction.South; break;
                    case ConsoleKey.LeftArrow: Console.Write("< "); direct = Direction.West; break;
                    case ConsoleKey.RightArrow: Console.Write("> "); direct = Direction.East; break;
                    default: return;
                }

                MapSite side = current.GetSide(direct);
                if (side is Door)
                {
                    current = ((Door)side).OtherSideFrom(current);
                    current.Enter();
                }
                else
                {
                    side.Enter();
                }
            }
        }
    }
}
