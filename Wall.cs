using System;

public class Wall : Element
{
    // Constructor
    public Wall(int x, int y) : base(x, y)
    {
        x = -1;
        y = -1;
    }

    // Methods
    public void place_wall(int x, int y, Element[,] board)
    {
        Element value = board[x, y];
        bool is_empty = false;

        // Check if its empty
        if (value == null){
            is_empty = true;
        }
        // If empty, add wall
        if (is_empty)
        {
            // Save positions
            this.x_pos = x;
            this.y_pos = y;
            board[x, y] = this;
        } else {
            // Not empty
            Console.WriteLine("PLACE NOT EMPTY");
        }

    }
}