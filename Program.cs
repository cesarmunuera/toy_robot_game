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
            Console.WriteLine();
            Console.WriteLine("Type a command:");
            string user_command = Console.ReadLine();
            //string user_command = "place_wall 1, 1";

            user_command = user_command.ToUpper(); //Upper always, to avoid problems

            // -------------------------------------------------------------------------
            if (user_command.StartsWith("PLACE_ROBOT"))
            {
                string[] parameters = user_command.Split(' ');
                int x = 0, y = 0;
                string orientation = "";
                bool valid_command = true;

                switch (parameters.Length)
                {
                    case 2:
                        string[] position = parameters[1].Split(',');
                        x = int.Parse(position[0]);
                        y = int.Parse(position[1]);
                        orientation = position[2];
                        break;

                    case 4:
                        x = int.Parse(parameters[1].Trim(','));
                        y = int.Parse(parameters[2].Trim(','));
                        orientation = (parameters[3].Trim(','));
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        valid_command = false;
                        break;
                }

                if (valid_command)
                {
                    if (valid_Position(x, y))
                    {
                        robo1.place_robot(x, y, orientation, board1);
                    }
                    else
                    {
                        Console.WriteLine("Input ranges not valid");
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
                        x = int.Parse(position[0]);
                        y = int.Parse(position[1]);
                        break;

                    case 3:
                        x = int.Parse(parameters[1].Trim(','));
                        y = int.Parse(parameters[2].Trim(','));
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        valid_command = false;
                        break;
                }

                if (valid_command)
                {
                    if (valid_Position(x, y))
                    {
                        wall = new Wall(x, y);
                        wall.place_wall(x, y, board1);
                    }
                    else
                    {
                        Console.WriteLine("Input ranges not valid");
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
            else
            {
                Console.WriteLine("Command not supported");
            }

        }
    }

    // This method checks if the range of X and Y is valid
    public bool valid_Position(int x_pos, int y_pos)
    {
        if ((x_pos >= 1 && x_pos <= 5) && (y_pos >= 1 && y_pos <= 5))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    static void Main(string[] args)
    {
        Program p = new Program();
        p.InitGame();
    }
}