using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;

namespace ToyRobotSimulatorUnitTests
{
    [TestClass]
    public class ToyRobotUnitTest
    {
        [TestMethod]
        public void TestPlace()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            int y = 0;
            Facing facing = Facing.North;
            
            // Run the method under test:  
            robot.Place(x,y,facing);
            // Verify the result:  
            Assert.AreEqual(robot.X, x);
            Assert.AreEqual(robot.Y, y);
            Assert.AreEqual(robot.Facing, facing);
        }
    }
}
