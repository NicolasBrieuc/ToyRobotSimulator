using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            var cmd = Console.ReadLine();
        }
    }
}
