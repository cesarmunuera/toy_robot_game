using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toy_robot_game
{
    public class Element
    {
        //Father class. Robot & wall inherit. Map made from this class.

        // Attributes
        public int x_pos { get; set; }
        public int y_pos { get; set; }

        // Constructor
        public Element(int x, int y)
        {
            x_pos = x;
            y_pos = y;
        }
    }
}
