using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json.Linq;
using toy_robot_game;


namespace TestRobot
{
    // ---------------------------------------------------------------------------------------------------------------------------------
    [TestClass]
    public class HappyTestsPath
    {
        Programa p = new Programa();
        Robot robo1 = new Robot(-1, -1, "N");

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

    }

    // ---------------------------------------------------------------------------------------------------------------------------------
    [TestClass]
    public class SadTestsPath
    {
        Programa p = new Programa();

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


    }


}