using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using toy_robot_game;


namespace TestRobot
{
    // ---------------------------------------------------------------------------------------------------------------------------------
    [TestClass]
    public class HappyTestsPath
    {
        Programa p = new Programa();
        Robot robo1 = new Robot(-1, -1, "N");
        Element[,] board1 = new Element[6, 6];
        Wall wall = new Wall(-1, -1);

        // -------------------------------------------------- METHODS FROM Program.cs --------------------------------------------------
        [TestMethod]
        public void Test_Valid_Orientation()
        {
            bool is_North = p.valid_Orientation("NORTH");
            bool is_SOUTH = p.valid_Orientation("SOUTH");
            bool is_WEST = p.valid_Orientation("WEST");
            bool is_EAST = p.valid_Orientation("EAST");

            Assert.AreEqual(true, is_North);
            Assert.AreEqual(true, is_SOUTH);
            Assert.AreEqual(true, is_WEST);
            Assert.AreEqual(true, is_EAST);
        }

        [TestMethod]
        public void Test_Valid_Position()
        {
            // It wil be true between 1 and 5
            bool is_InRange = p.valid_Position(2, 2);
            Assert.AreEqual(true, is_InRange);

        }

        //[TestMethod]
        //public void Test_InitGame()
        //{
        //    // Should test the result comparing by robo1.report data
        //}

        // --------------------------------------------------- METHODS FROM Robot.cs ---------------------------------------------------
        [TestMethod]
        public void Test_place_robot()
        {
            int x = 1, y = 1;
            string ori = "NORTH";

            robo1.place_robot(x, y, ori, board1);

            //Check map and robot attributes 
            bool isWorking = ((board1[x, y] != null) && (robo1.x_pos == x) && (robo1.y_pos == y) && (robo1.orientation == ori));
            Assert.AreEqual(true, isWorking);
        }

        [TestMethod]
        public void Test_report()
        {
            // Set robot
            int x = 1, y = 1;
            string ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);

            // Check report
            (int x_rep, int y_rep, string ori_rep) = robo1.report();
            bool report_working = ((x_rep == x) && (y_rep == y) && (ori_rep == ori));
            Assert.AreEqual(true, report_working);
        }

        [TestMethod]
        public void Test_move()
        {
            int x, y;
            string ori;
            bool is_working;

            // To the left, in edge
            // Set robot
            x = 1;
            y = 1;
            ori = "WEST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == 5) && (robo1.y_pos == y) && (robo1.orientation == ori));

            // To the left
            // Set robot
            x = 3;
            y = 2;
            ori = "WEST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == 2) && (robo1.y_pos == y) && (robo1.orientation == ori));

            // Up, in edge
            // Set robot
            x = 2;
            y = 1;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == x) && (robo1.y_pos == 5) && (robo1.orientation == ori));

            // Up
            // Set robot
            x = 5;
            y = 3;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == x) && (robo1.y_pos == 4) && (robo1.orientation == ori));

            // To the right, in edge
            // Set robot
            x = 5;
            y = 2;
            ori = "EAST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == 1) && (robo1.y_pos == y) && (robo1.orientation == ori));

            // To the right,
            // Set robot
            x = 3;
            y = 4;
            ori = "EAST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == 4) && (robo1.y_pos == y) && (robo1.orientation == ori));


            // Down, in edge
            // Set robot
            x = 1;
            y = 1;
            ori = "SOUTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == x) && (robo1.y_pos == 5) && (robo1.orientation == ori));

            // Up
            // Set robot
            x = 2;
            y = 4;
            ori = "SOUTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_working = ((robo1.x_pos == x) && (robo1.y_pos == 3) && (robo1.orientation == ori));

            Assert.AreEqual(true, is_working);

        }

        [TestMethod]
        public void test_tour()
        {
            int x, y;
            string ori;
            bool is_workingRight, is_workingLeft;

            // Set robot
            x = 1;
            y = 1;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_workingRight = ((robo1.orientation == "EAST"));

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_workingRight = ((robo1.orientation == "SOUTH"));

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_workingRight = ((robo1.orientation == "WEST"));

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_workingRight = ((robo1.orientation == "NORTH"));

            // Set robot 
            x = 1;
            y = 2;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);


            //Change direction
            robo1.tour("LEFT");
            //Check
            is_workingLeft = ((robo1.orientation == "WEST"));

            //Change direction
            robo1.tour("LEFT");
            //Check
            is_workingLeft = ((robo1.orientation == "SOUTH"));

            //Change direction
            robo1.tour("LEFT");
            //Check
            is_workingLeft = ((robo1.orientation == "EAST"));

            //Change direction
            robo1.tour("LEFT");
            //Check
            is_workingLeft = ((robo1.orientation == "NORTH"));


            Assert.AreEqual(true, is_workingRight);
            Assert.AreEqual(true, is_workingLeft);
        }
        
        // ---------------------------------------------------- METHODS FROM Wall.cs ----------------------------------------------------
        [TestMethod]
        public void test_place_wall()
        {
            int x = 1, y = 1;
            wall.place_wall(x, y, board1);

            //Check map and robot attributes 
            bool isWorking = ((board1[x, y] != null) && (wall.x_pos == x) && (wall.y_pos == y));
            Assert.AreEqual(true, isWorking);
        }


    }

    // ---------------------------------------------------------------------------------------------------------------------------------
    [TestClass]
    public class SadTestsPath
    {
        Programa p = new Programa();
        Robot robo1 = new Robot(-1, -1, "N");
        Element[,] board1 = new Element[6, 6];
        Wall wall = new Wall(-1, -1);

        // -------------------------------------------------- METHODS FROM Program.cs --------------------------------------------------
        [TestMethod]
        public void Test_Valid_Orientation()
        {
            bool is_North = p.valid_Orientation("north");
            bool is_SOUTH = p.valid_Orientation("south");
            bool is_WEST = p.valid_Orientation("west");
            bool is_EAST = p.valid_Orientation("east");

            Assert.AreEqual(false, is_North);
            Assert.AreEqual(false, is_SOUTH);
            Assert.AreEqual(false, is_WEST);
            Assert.AreEqual(false, is_EAST);
        }

        [TestMethod]
        public void Test_Valid_Position()
        {
            // It wil be true between 1 and 5 
            bool is_InRange = p.valid_Position(0, 0);
            Assert.AreEqual(false, is_InRange);

            // It wil be true between 1 and 5 
            is_InRange = p.valid_Position(7, 7);
            Assert.AreEqual(false, is_InRange);
        }

        //[TestMethod]
        //public void Test_InitGame()
        //{
        //    // Should test the result comparing by robo1.report data
        //}

        // --------------------------------------------------- METHODS FROM Robot.cs ---------------------------------------------------
        [TestMethod]
        public void Test_place_robot()
        {
            int x = 1, y = 1;
            string ori = "NORTH";

            robo1.place_robot(x, y, ori, board1);

            //Check map and robot attributes 
            bool isNotWorking = ((board1[x, y] == null) || (robo1.x_pos != x) || (robo1.y_pos != y));
            Assert.AreEqual(false, isNotWorking);
        }

        [TestMethod]
        public void Test_report()
        {
            // Set robot
            int x = 1, y = 1;
            string ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);

            // Check report
            (int x_rep, int y_rep, string ori_rep) = robo1.report();
            bool report_not_working = ((x_rep != x) || (y_rep != y) || (ori_rep != ori));
            Assert.AreEqual(false, report_not_working);
        }

        [TestMethod]
        public void Test_move()
        {
            int x, y;
            string ori;
            bool is_not_working;

            // To the left, in edge
            // Set robot
            x = 1;
            y = 1;
            ori = "WEST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != 5) || (robo1.y_pos != y) || (robo1.orientation != ori));

            // To the left
            // Set robot
            x = 3;
            y = 2;
            ori = "WEST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != 2) || (robo1.y_pos != y) || (robo1.orientation != ori));

            // Up, in edge
            // Set robot
            x = 2;
            y = 1;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != x) || (robo1.y_pos != 5) || (robo1.orientation != ori));

            // Up
            // Set robot
            x = 5;
            y = 3;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != x) || (robo1.y_pos != 4) || (robo1.orientation != ori));

            // To the right, in edge
            // Set robot
            x = 5;
            y = 2;
            ori = "EAST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != 1) || (robo1.y_pos != y) || (robo1.orientation != ori));

            // To the right,
            // Set robot
            x = 3;
            y = 4;
            ori = "EAST";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != 4) || (robo1.y_pos != y) || (robo1.orientation != ori));


            // Down, in edge
            // Set robot
            x = 1;
            y = 1;
            ori = "SOUTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != x) || (robo1.y_pos != 5) || (robo1.orientation != ori));

            // Up
            // Set robot
            x = 2;
            y = 4;
            ori = "SOUTH";
            robo1.place_robot(x, y, ori, board1);
            //Move
            robo1.move(board1);
            //Check
            is_not_working = ((robo1.x_pos != x) || (robo1.y_pos != 3) || (robo1.orientation != ori));

            Assert.AreEqual(false, is_not_working);
        }

        [TestMethod]
        public void test_tour()
        {
            int x, y;
            string ori;
            bool is_NotWorkingRight, is_NotWorkingLeft;

            // Set robot
            x = 1;
            y = 1;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_NotWorkingRight = ((robo1.orientation != "EAST"));

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_NotWorkingRight = ((robo1.orientation != "SOUTH"));

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_NotWorkingRight = ((robo1.orientation != "WEST"));

            //Change direction
            robo1.tour("RIGHT");
            //Check
            is_NotWorkingRight = ((robo1.orientation != "NORTH"));

            // Set robot 
            x = 1;
            y = 2;
            ori = "NORTH";
            robo1.place_robot(x, y, ori, board1);


            //Change direction
            robo1.tour("LEFT");
            //Check
            is_NotWorkingLeft = ((robo1.orientation != "WEST"));

            //Change direction
            robo1.tour("LEFT");
            //Check
            is_NotWorkingLeft = ((robo1.orientation != "SOUTH"));

            //Change direction
            robo1.tour("LEFT");
            //Check
            is_NotWorkingLeft = ((robo1.orientation != "EAST"));

            //Change direction
            robo1.tour("LEFT");
            //Check
            is_NotWorkingLeft = ((robo1.orientation != "NORTH"));


            Assert.AreEqual(false, is_NotWorkingRight);
            Assert.AreEqual(false, is_NotWorkingLeft);
        }

        // ---------------------------------------------------- METHODS FROM Wall.cs ----------------------------------------------------
        [TestMethod]
        public void Test_place_wall()
        {
            int x = 1, y = 1;
            wall.place_wall(x, y, board1);

            //Check map and robot attributes 
            bool isNotWorking = ((board1[x, y] == null) || (wall.x_pos != x) || (wall.y_pos != y));
            Assert.AreEqual(false, isNotWorking);
        }

    }

}