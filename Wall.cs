using System;

// First wall is initialized out of map
// So if not in the map, theres is no wall yet

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
        // If empty, add wall
        if (board[x, y] == null)
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