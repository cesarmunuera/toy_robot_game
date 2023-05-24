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

    // Método
    public void place_robot(int x, int y, string ori, Element[,] board)
    {
        Element value = board[x, y];
        bool is_empty = false;

        // Check if its empty
        if (value == null){
            is_empty = true;
        }
        // If its empty, delete last position in map, and update robot values
        if (is_empty)
        {
            // Delete last position
            board[this.x_pos, this.y_pos] = null;

            // Save positions
            this.x_pos = x;
            this.y_pos = y;
            this.orientation = ori;
            board[x, y] = this;
        } else {
            Console.WriteLine("PLACE NOT EMPTY");
        }

    }

    public (int, int, string) report(){
        return (this.x_pos, this.y_pos, this.orientation);
    }
}
