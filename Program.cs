using System;

class Program
{
    public Element[,] bd1 = new Element[5, 5];
    public Robot robo1 = new Robot(1, 1, "North");


    public void InitGame()
    {
        robo1.place_robot(1, 1, "North", bd1);

        while (true)
        {
            Console.WriteLine("Type a command:");
            string user_command = Console.ReadLine();

            // -------------------------------------------------------------------------
            if (user_command.StartsWith("PLACE_ROBOT"))
            {
                string[] parameters = user_command.Split(' ');
                int x = 0, y = 0;
                string orientation = "";

                Console.WriteLine("SIZE -> " + parameters.Length);

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
                        break;
                }
                robo1.place_robot(x, y, orientation, bd1);

            }
            // -------------------------------------------------------------------------
            else if (user_command.StartsWith("PLACE_WALL"))
            {
                string[] parameters = user_command.Split(' ');
                if (parameters.Length == 2)
                {
                    string[] position = parameters[1].Split(",");
                    int x = int.Parse(position[0].Trim());
                    int y = int.Parse(position[1].Trim());

                    // Place wall at x, y position
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
            // -------------------------------------------------------------------------
            else if(user_command == "REPORT")
            {
                (int x, int y, string ori) = robo1.report();
                Console.WriteLine(x + "," + y + "," + ori);

            }
            // -------------------------------------------------------------------------
            else
            {
                Console.WriteLine("Command not supported");
            }

        }
    }


    static void Main(string[] args)
    {
        Program p = new Program();
        p.InitGame();
    }
}