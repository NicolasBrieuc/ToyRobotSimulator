﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;

namespace ToyRobotSimulatorUnitTests
{
    [TestClass]
    public class ToyRobotUnitTest
    {
        [TestMethod]
        public void TestPlaceOnTable()
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
        
        [TestMethod]
        public void TestPlaceOutOfTableExceptionXMin()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int y = 0;
            Facing facing = Facing.North;

            // Run the method under test:
            try
            {
                robot.Place(-1, y, facing);
                Assert.Fail("Must an integer between 0 and 4");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestPlaceOutOfTableExceptionXMax()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            int y = 0;
            Facing facing = Facing.North;

            // Run the method under test:
            try
            {
                robot.Place(5, y, facing);
                Assert.Fail("Must an integer between 0 and 4");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestPlaceOutOfTableExceptionYMin()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            Facing facing = Facing.North;

            // Run the method under test:
            try
            {
                robot.Place(x, -1, facing);
                Assert.Fail("Must an integer between 0 and 4");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestPlaceOutOfTableExceptionYMax()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            Facing facing = Facing.North;

            // Run the method under test:
            try
            {
                robot.Place(x, 5, facing);
                Assert.Fail("Must an integer between 0 and 4");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestMoveOnTable()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            int y = 0;
            Facing facing = Facing.North;

            robot.Place(x, y, facing);

            // Run the method under test and verify test when facing North  
            robot.Move();
            Assert.AreEqual(robot.X, 0);
            Assert.AreEqual(robot.Y, 1);
            Assert.AreEqual(robot.Facing, Facing.North);
            // Run the method under test and verify test when facing East
            robot.GetType().GetProperty("Facing").SetValue(robot, Facing.East);
            robot.Move();
            Assert.AreEqual(robot.X, 1);
            Assert.AreEqual(robot.Y, 1);
            Assert.AreEqual(robot.Facing, Facing.East);
            // Run the method under test and verify test when facing South
            robot.GetType().GetProperty("Facing").SetValue(robot, Facing.South);
            robot.Move();
            Assert.AreEqual(robot.X, 1);
            Assert.AreEqual(robot.Y, 0);
            Assert.AreEqual(robot.Facing, Facing.South);
            // Run the method under test and verify test when facing West
            robot.GetType().GetProperty("Facing").SetValue(robot, Facing.West);
            robot.Move();
            Assert.AreEqual(robot.X, 0);
            Assert.AreEqual(robot.Y, 0);
            Assert.AreEqual(robot.Facing, Facing.West);
        }

        [TestMethod]
        public void TestMoveRobotWillFallException()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 4;
            int y = 4;
            Facing facing = Facing.North;

            robot.Place(x, y, facing);

            // Run the method under test and verify test when facing North  
            try
            {
                robot.Move();
                Assert.Fail("Robot will fall");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(RobotWillFallException), ex.GetType(), ex.Message);
            }
            
            // Run the method under test and verify test when facing East
            robot.GetType().GetProperty("Facing").SetValue(robot, Facing.East);
            try
            {
                robot.Move();
                Assert.Fail("Robot will fall");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(RobotWillFallException), ex.GetType(), ex.Message);
            }
            // Run the method under test and verify test when facing South
            robot.GetType().GetProperty("Facing").SetValue(robot, Facing.South);
            robot.GetType().GetProperty("Y").SetValue(robot, 0);
            try
            {
                robot.Move();
                Assert.Fail("Robot will fall");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(RobotWillFallException), ex.GetType(), ex.Message);
            }
            // Run the method under test and verify test when facing West
            robot.GetType().GetProperty("Facing").SetValue(robot, Facing.West);
            robot.GetType().GetProperty("X").SetValue(robot, 0);
            try
            {
                robot.Move();
                Assert.Fail("Robot will fall");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(RobotWillFallException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestMoveNoValidPlaceCommandExecutedException()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            
            // Run the method under test:
            try
            {
                robot.Move();
                Assert.Fail("A valid Place command needs to be executed first");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(NoValidPlaceCommandExecutedException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestLeftWhenCorrectlyPlaced()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            int y = 0;
            Facing facing = Facing.North;
      
            robot.Place(x, y, facing);

            // Run the method under test and verify result
            robot.Left();
            Assert.AreEqual(robot.Facing, Facing.West);
            robot.Left();
            Assert.AreEqual(robot.Facing, Facing.South);
            robot.Left();
            Assert.AreEqual(robot.Facing, Facing.East);
            robot.Left();
            Assert.AreEqual(robot.Facing, Facing.North);
        }

        public void TestLeftNoValidPlaceCommandExecutedException()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();

            // Run the method under test:
            try
            {
                robot.Left();
                Assert.Fail("A valid Place command needs to be executed first");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(NoValidPlaceCommandExecutedException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestRightWhenCorrectlyPlaced()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            int y = 0;
            Facing facing = Facing.North;
            robot.Place(x, y, facing);
            // Run the method under test and verify result
            robot.Right(); 
            Assert.AreEqual(robot.Facing, Facing.East);
            robot.Right();
            Assert.AreEqual(robot.Facing, Facing.South);
            robot.Right();
            Assert.AreEqual(robot.Facing, Facing.West);
            robot.Right();
            Assert.AreEqual(robot.Facing, Facing.North);
        }

        [TestMethod]
        public void TestRightNoValidPlaceCommandExecutedException()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();

            // Run the method under test:
            try
            {
                robot.Right();
                Assert.Fail("A valid Place command needs to be executed first");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(NoValidPlaceCommandExecutedException), ex.GetType(), ex.Message);
            }
        }

        [TestMethod]
        public void TestReportWhenCorrectlyPlaced()
        {
            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();
            // Define a test input and output value:  
            int x = 0;
            int y = 0;
            Facing facing = Facing.North;

            robot.Place(x, y, facing);

            // Run the method under test:  
            string location = robot.Report();
            // Verify the result:  
            Assert.AreEqual("0,0,NORTH", location);
            
        }

        [TestMethod]
        public void TestReportNoValidPlaceCommandExecutedException()
        {

            // Create an instance to test:  
            ToyRobot robot = new ToyRobot();

            // Run the method under test:
            try
            {
                robot.Report();
                Assert.Fail("A valid Place command needs to be executed first");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(NoValidPlaceCommandExecutedException), ex.GetType(), ex.Message);
            }
        }
    }
}
