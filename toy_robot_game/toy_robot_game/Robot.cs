using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toy_robot_game
{
    public class Robot : Element
    {
        // Attributes
        public string orientation { get; set; }

        // Constructor
        public Robot(int x, int y, string ori) : base(x, y)
        {
            orientation = ori;
        }

        // Methods
        public void place_robot(int x, int y, string ori, Element[,] board)
        {
            // If empty, delete last position in map, and update robot values
            if (board[x, y] == null)
            {
                // Delete last position, if a robot exists
                if (this.x_pos != -1)
                {
                    board[this.x_pos, this.y_pos] = null;
                }

                // Save positions
                this.x_pos = x;
                this.y_pos = y;
                this.orientation = ori;
                board[x, y] = this;
            }
            else
            {
                // Not empty
                Console.WriteLine("PLACE NOT EMPTY");
            }
        }

        // Report robot position
        public (int, int, string) report()
        {
            if (this.x_pos == -1)
            {
                return (0, 0, " No robot yet !!");
            }
            else
            {
                return (this.x_pos, this.y_pos, this.orientation);
            }
        }

        // Move robot 1 position, depending on its direction
        public void move(Element[,] board)
        {
            int next_x = 0, next_y = 0;

            // Check if robot exists
            if (this.x_pos != -1)
            {
                // Check orientation
                switch (this.orientation)
                {
                    case "NORTH":
                        if (this.y_pos == 5)
                        {
                            next_y = 1;
                            next_x = this.x_pos;
                        }
                        else
                        {
                            next_y = this.y_pos + 1;
                            next_x = this.x_pos;
                        }
                        break;

                    case "SOUTH":
                        if (this.y_pos == 1)
                        {
                            next_y = 5;
                            next_x = this.x_pos;
                        }
                        else
                        {
                            next_y = this.y_pos - 1;
                            next_x = this.x_pos;
                        }
                        break;

                    case "EAST":
                        if (this.x_pos == 5)
                        {
                            next_x = 1;
                            next_y = this.y_pos;
                        }
                        else
                        {
                            next_x = this.x_pos + 1;
                            next_y = this.y_pos;
                        }
                        break;

                    case "WEST":
                        if (this.x_pos == 1)
                        {
                            next_x = 5;
                            next_y = this.y_pos;
                        }
                        else
                        {
                            next_x = this.x_pos - 1;
                            next_y = this.y_pos;
                        }
                        break;
                }

                if (board[next_x, next_y] == null)
                {
                    this.x_pos = next_x;
                    this.y_pos = next_y;
                    board[next_x, next_y] = this;
                }
                else
                {
                    Console.WriteLine("Position not empty");
                }

            }
            else
            {
                Console.WriteLine("No robot yet !!");
            }

        }

        public void tour(String new_Orientation)
        {
            if (new_Orientation == "RIGHT")
            {
                switch (this.orientation)
                {
                    case "NORTH":
                        this.orientation = "EAST";
                        break;

                    case "EAST":
                        this.orientation = "SOUTH";
                        break;

                    case "SOUTH":
                        this.orientation = "WEST";

                        break;
                    case "WEST":
                        this.orientation = "NORTH";
                        break;
                }
            }
            else if (new_Orientation == "LEFT")
            {
                switch (this.orientation)
                {
                    case "NORTH":
                        this.orientation = "WEST";
                        break;
                    case "WEST":
                        this.orientation = "SOUTH";
                        break;
                    case "SOUTH":
                        this.orientation = "EAST";
                        break;
                    case "EAST":
                        this.orientation = "NORTH";
                        break;

                }
            }
        }
    }
}
