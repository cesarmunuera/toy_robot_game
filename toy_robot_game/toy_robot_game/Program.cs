using System;
using System.Numerics;
using System.Xml.Linq;

namespace toy_robot_game
{
    public class Programa
    {
        public Element?[,] board1 = new Element?[6, 6];
        public Robot robo1 = new Robot(-1, -1, "N");
        public Wall? wall;


        public void InitGame()
        {

            while (true)
            {
                // Get values from keyboard
                Console.WriteLine();
                Console.WriteLine("Type a command:");
                string user_command = Console.ReadLine() ?? "";

                user_command = user_command.ToUpper(); //Upper always, to avoid problems

                // -------------------------------------------------------------------------
                if (user_command.StartsWith("PLACE_ROBOT")) //PLACE_ROBOT COMMAND
                {
                    int x = 0, y = 0;
                    string orientation = "";
                    bool valid_command = false;

                    //Get position of the first space
                    int firstSpaceIndex = user_command.IndexOf(' ');

                    // If command structure is correct
                    if (firstSpaceIndex != -1)
                    {
                        //Get parameters, delete spaces, separate them by comma
                        string parameters = user_command.Substring(firstSpaceIndex + 1);
                        string filtered_space_parameters = parameters.Replace(" ", "");
                        string[] final_parameters = filtered_space_parameters.Split(",");

                        //Check if there are the correct number of values, and if 1st and 2nd values are int
                        if ((final_parameters.Length == 3) && (int.TryParse(final_parameters[0], out _)) && (int.TryParse(final_parameters[1], out _)))
                        {
                            x = int.Parse(final_parameters[0]);
                            y = int.Parse(final_parameters[1]);
                            orientation = final_parameters[2];

                            valid_command = true;
                        }
                    }

                    if (valid_command)
                    {
                        // If command is correct (position and orientation), set
                        if (valid_Position(x, y) && valid_Orientation(orientation))
                        {
                            robo1.place_robot(x, y, orientation, board1);
                        }
                        //else
                        //{
                        //    Console.WriteLine("Input values or orientation not valid");
                        //}
                    }

                }
                // -------------------------------------------------------------------------
                else if (user_command.StartsWith("PLACE_WALL"))
                {
                    int x = 0, y = 0;
                    bool valid_command = false;

                    //Get position of the first space
                    int firstSpaceIndex = user_command.IndexOf(' ');

                    // If command structure is correct
                    if (firstSpaceIndex != -1)
                    {
                        //Get parameters, delete spaces, separate them by comma
                        string parameters = user_command.Substring(firstSpaceIndex + 1);
                        string filtered_space_parameters = parameters.Replace(" ", "");
                        string[] final_parameters = filtered_space_parameters.Split(",");

                        //Check if there are the correct number of values, and if 1st and 2nd values are int
                        if ((final_parameters.Length == 2) && (int.TryParse(final_parameters[0], out _)) && (int.TryParse(final_parameters[1], out _)))
                        {
                            x = int.Parse(final_parameters[0]);
                            y = int.Parse(final_parameters[1]);

                            valid_command = true;
                        }
                    }

                    // If command is correct (position and orientation), set
                    if (valid_command)
                    {
                        if (valid_Position(x, y))
                        {
                            wall = new Wall(x, y);
                            wall.place_wall(x, y, board1);
                        }
                        //else
                        //{
                        //    Console.WriteLine("Input values not valid");
                        //}
                    }

                }
                // -------------------------------------------------------------------------
                else if (user_command == "REPORT")
                {
                    (int x, int y, string ori) = robo1.report();
                    Console.WriteLine(x + "," + y + "," + ori);
                }
                // -------------------------------------------------------------------------
                else if (user_command == "MOVE")
                {
                    robo1.move(board1);
                }
                // -------------------------------------------------------------------------
                else if (user_command == "LEFT" || user_command == "RIGHT")
                {
                    robo1.tour(user_command);

                }
                // -------------------------------------------------------------------------
                //else
                //{
                //    Console.WriteLine("Command not supported");
                //}

            }
        }

        // This method checks if the range of X and Y is valid
        public bool valid_Position(int x_pos, int y_pos)
        {
            return ((x_pos >= 1 && x_pos <= 5) && (y_pos >= 1 && y_pos <= 5));
        }

        // This methos checks if the orientation is correct
        public bool valid_Orientation(String orientation)
        {
            return (orientation == "NORTH" || orientation == "SOUTH" || orientation == "EAST" || orientation == "WEST");
        }

        static void Main(string[] args)
        {
            Programa p = new Programa();
            p.InitGame();
        }
    }
}