using System;

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
        Element value = board[x, y];
        bool is_empty = false;

        // Check if its empty
        if (value == null)
        {
            is_empty = true;
        }
        // If empty, delete last position in map, and update robot values
        if (is_empty)
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
        // Check if robot exists
        if (this.x_pos != -1)
        {
            // Check orientation
            switch (this.orientation)
            {
                case "NORTH":
                    if (this.y_pos == 5)
                    {
                        this.y_pos = 1;
                    }
                    else
                    {
                        this.y_pos = this.y_pos + 1;
                    }
                    break;

                case "SOUTH":
                    if (this.y_pos == 1)
                    {
                        this.y_pos = 5;
                    }
                    else
                    {
                        this.y_pos = this.y_pos - 1;
                    }
                    break;

                case "EAST":
                    if (this.x_pos == 5)
                    {
                        this.x_pos = 1;
                    }
                    else
                    {
                        this.x_pos = this.x_pos + 1;
                    }
                    break;

                case "WEST":
                    if (this.x_pos == 1)
                    {
                        this.x_pos = 5;
                    }
                    else
                    {
                        this.x_pos = this.x_pos - 1;
                    }
                    break;
            } 

        } else {
                Console.WriteLine("No robot yet !!");
            }

    }

}
