using System;

class Program
{
    public Element[,] board1 = new Element[6, 6];
    public Robot robo1 = new Robot(-1, -1, "N");
    public Wall wall;


    public void InitGame()
    {

        while (true)
        {
            // Get values from keyboard
            Console.WriteLine();
            Console.WriteLine("Type a command:");
            string user_command = Console.ReadLine();
            //string user_command = "place_wall 1, 1";

            user_command = user_command.ToUpper(); //Upper always, to avoid problems

            // -------------------------------------------------------------------------
            if (user_command.StartsWith("PLACE_ROBOT")) //PLACE_ROBOT COMMAND
            {
                string[] parameters = user_command.Split(' ');
                int x = 0, y = 0;
                string orientation = "";
                bool valid_command = true;


                switch (parameters.Length)
                {
                    case 2:
                        string[] position = parameters[1].Split(',');

                        //Chek if 1st and 2nd values are int
                        if ((int.TryParse(position[0], out _)) && (int.TryParse(position[1], out _)))
                        {
                            x = int.Parse(position[0]);
                            y = int.Parse(position[1]);
                            orientation = position[2];
                        }
                        break;

                    case 4:
                        //Chek if 1st and 2nd values are int
                        if ((int.TryParse(parameters[1].Trim(','), out _)) && (int.TryParse(parameters[2].Trim(','), out _)))
                        {
                            x = int.Parse(parameters[1].Trim(','));
                            y = int.Parse(parameters[2].Trim(','));
                            orientation = (parameters[3].Trim(','));
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        valid_command = false;
                        break;
                }

                if (valid_command)
                {
                    // If command is correct (position and orientation), set
                    if (valid_Position(x, y) && valid_Orientation(orientation))
                    {
                        robo1.place_robot(x, y, orientation, board1);
                    }
                    else
                    {
                        Console.WriteLine("Input values or orientation not valid");
                    }
                }

            }
            // -------------------------------------------------------------------------
            else if (user_command.StartsWith("PLACE_WALL"))
            {
                string[] parameters = user_command.Split(' ');
                int x = 0, y = 0;
                bool valid_command = true;

                switch (parameters.Length)
                {
                    case 2:
                        string[] position = parameters[1].Split(',');
                        //Chek if 1st and 2nd values are int
                        if ((int.TryParse(position[0], out _)) && (int.TryParse(position[1], out _)))
                        {
                            x = int.Parse(position[0]);
                            y = int.Parse(position[1]);
                        }
                        break;

                    case 3:
                        //Chek if 1st and 2nd values are int
                        if ((int.TryParse(parameters[1].Trim(','), out _)) && (int.TryParse(parameters[2], out _)))
                        {
                            x = int.Parse(parameters[1].Trim(','));
                            y = int.Parse(parameters[2].Trim(','));
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        valid_command = false;
                        break;
                }

                // If command is correct (position and orientation), set
                if (valid_command)
                {
                    if (valid_Position(x, y))
                    {
                        wall = new Wall(x, y);
                        wall.place_wall(x, y, board1);
                    }
                    else
                    {
                        Console.WriteLine("Input values not valid");
                    }
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
            else
            {
                Console.WriteLine("Command not supported");
            }

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
        Program p = new Program();
        p.InitGame();
    }
}