using System;

class Program
{
    static string[,] board = new string[5, 5];

    static void Main(string[] args)
    {
        //Init table
        //Init robot

        while (true)
        {
            Console.WriteLine("Type a command:");
            string user_command = Console.ReadLine();

            if (user_command.StartsWith("PLACE_ROBOT"))
            {
                string[] parameters = user_command.Split(' ');
                if (parameters.Length == 2)
                {
                    string[] position = parameters[1].Split(',');
                    int x = int.Parse(position[0].Trim());
                    Console.WriteLine("X pos = " + x);
                    int y = int.Parse(position[1].Trim());
                    Console.WriteLine("Y pos = " + y);
                    string orientation = position[2].Trim();
                    Console.WriteLine("Ori pos = " + orientation);

                    // Place wall at x, y position
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
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
            else
            {
                Console.WriteLine("Command not supported");
            }
        }
    }
}
