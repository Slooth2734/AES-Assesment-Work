using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Square : Shape
    {
        public static readonly int DeafultSide = 30;
        internal int Side { get; set; }

        public Square() : this(DeafultSide)
        {

        }

        public Square(int side)
        {
            Side = side;
        }

        public Square(Point position, int side) : base(position)
        {
            Side = side;
        }


    }
}
