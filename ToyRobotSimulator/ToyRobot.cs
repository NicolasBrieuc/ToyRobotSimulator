using System;

namespace ToyRobotSimulator
{

    public class RobotWillFallException : Exception
    {
        public RobotWillFallException()
        {
        }

        public RobotWillFallException(string message)
            : base(message)
        {
        }

        public RobotWillFallException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NoValidPlaceCommandExecutedException : Exception
    {
        public NoValidPlaceCommandExecutedException()
        {
        }

        public NoValidPlaceCommandExecutedException(string message)
            : base(message)
        {
        }

        public NoValidPlaceCommandExecutedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ToyRobot
    {
        public ToyRobot()
        {
        }

        private bool _validPlaceExecuted { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Facing Facing { get; private set; }

        public void Place(int x, int y, Facing facing)
        {
            const string intErrorMessage = "Must an integer between 0 and 4";

            if (x < 0 || x > 4)
                throw new ArgumentOutOfRangeException("x", intErrorMessage);

            if (y < 0 || y > 4)
                throw new ArgumentOutOfRangeException("y", intErrorMessage);
            
            X = x;
            Y = y;
            Facing = facing;
            _validPlaceExecuted = true;
        }

        public void Move()
        {
            if (!_validPlaceExecuted)
                throw new NoValidPlaceCommandExecutedException();

            switch (Facing)
            {
                case Facing.North:
                    if (Y >= 4)
                        throw new RobotWillFallException();
                    Y = Y + 1;
                    break;
                case Facing.East:
                    if (X >= 4)
                        throw new RobotWillFallException();
                    X = X + 1;
                    break;
                case Facing.South:
                    if (Y <= 0)
                        throw new RobotWillFallException();
                    Y = Y - 1;
                    break;
                case Facing.West:
                    if (X <= 0)
                        throw new RobotWillFallException();
                    X = X - 1;
                    break;
            }
        }

        public void Left()
        {
            if (!_validPlaceExecuted)
                throw new NoValidPlaceCommandExecutedException();

            switch (Facing)
                {
                case Facing.North:
                    Facing = Facing.West;
                    break;
                case Facing.East:
                    Facing = Facing.North;
                    break;
                case Facing.South:
                    Facing = Facing.East;
                    break;
                case Facing.West:
                    Facing = Facing.South;
                    break;
            }
        }

        public void Right()
        {
            if (!_validPlaceExecuted)
                throw new NoValidPlaceCommandExecutedException();

            switch (Facing)
            {
                case Facing.North:
                    Facing = Facing.East;
                    break;
                case Facing.East:
                    Facing = Facing.South;
                    break;
                case Facing.South:
                    Facing = Facing.West;
                    break;
                case Facing.West:
                    Facing = Facing.North;
                    break;
            }
        }

        public string Report()
        {
            if (!_validPlaceExecuted)
                throw new NoValidPlaceCommandExecutedException();

            return string.Format(
                "{0},{1},{2}",
                X.ToString(),
                Y.ToString(),
                Facing.ToString().ToUpper()
                );
        }
    }
}