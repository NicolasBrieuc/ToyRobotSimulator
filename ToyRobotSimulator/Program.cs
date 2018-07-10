using System;
using System.Text.RegularExpressions;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Toy Robot Simulator");
            Console.WriteLine();
            Console.WriteLine("The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.");
            Console.WriteLine("There are no other obstructions on the table surface.");
            Console.WriteLine("The origin (0,0) can be considered to be the SOUTH WEST most corner");
            Console.WriteLine();
            Console.WriteLine("The following commands can be used to interact with the robot:");
            Console.WriteLine(" - PLACE X,Y,F => PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST");
            Console.WriteLine(" - MOVE => MOVE will move the toy robot one unit forward in the direction it is currently facing");
            Console.WriteLine(" - LEFT / RIGHT => LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot");
            Console.WriteLine(" - REPORT => REPORT will announce the X,Y and F of the robot");
            Console.WriteLine(" - EXIT => REPORT will exit and close the simulator");

            var toyRobot = new ToyRobot();

            while (true)
            {
                var input = Console.ReadLine().ToUpper().Trim();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                
                try
                {
                    switch (input)
                    {

                        case var someVal when new Regex(@"(PLACE) [0-4],[0-4],(NORTH|SOUTH|EAST|WEST)").IsMatch(someVal):
                            string parameters = someVal.Replace("PLACE ", string.Empty);
                            int x = int.Parse(parameters.Substring(0,1));
                            int y = int.Parse(parameters.Substring(2, 1));
                            string facing = parameters.Substring(4);
                            switch (facing)
                            {
                                case "NORTH":
                                    toyRobot.Place(x, y, Facing.North);
                                    break;
                                case "SOUTH":
                                    toyRobot.Place(x, y, Facing.South);
                                    break;
                                case "EAST":
                                    toyRobot.Place(x, y, Facing.East);
                                    break;
                                case "WEST":
                                    toyRobot.Place(x, y, Facing.West);
                                    break;
                            }
                            break;
                        case "MOVE":
                            toyRobot.Move();
                            break;
                        case "LEFT":
                            toyRobot.Left();
                            break;
                        case "RIGHT":
                            toyRobot.Right();
                            break;
                        case "REPORT":
                            Console.WriteLine(toyRobot.Report());
                            break;
                        default:
                            Console.WriteLine("Not a valid command! Please try again.");
                            break;
                    }
                }
                catch (NoValidPlaceCommandExecutedException)
                {
                    Console.WriteLine("No valid Place command previously executed! Please try again");
                }
                catch (RobotWillFallException)
                {
                    Console.WriteLine("This move will make the robot fall! Please try again");
                }
            }
        }
    }
}

