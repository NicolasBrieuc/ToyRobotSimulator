using System;

namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        public ToyRobot()
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Facing Facing { get; set; }

        public void Place(int x, int y, Facing facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }
}