using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace toy_robot_game
{
    public class Wall:Element
    {

        public Wall(int x, int y) : base(x, y)
        {
            x = -1;
            y = -1;
        }

        // Methods
        public void place_wall(int x, int y, Element?[,] board)
        {
            // If empty, add wall
            if (board[x, y] == null)
            {
                // Save positions
                this.x_pos = x;
                this.y_pos = y;
                board[x, y] = this;

            }
            //else
            //{
            //    // Not empty
            //    Console.WriteLine("PLACE NOT EMPTY");
            //}
        }
    }
}
