using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    abstract class Shape
    {
        //public Point DeafultPoint = new Point(0, 0);
        //public Point CurrentPoint {  get; set; }

        protected Color colour;
        public int x, y;
        public bool? onOff;

        public Shape(Color colour, int x, int y) 
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }
        //public Shape(Point position) 
        //{
        //    CurrentPoint = position;
        //}

        public abstract void Draw(Graphics graphics);

        public abstract void Fill(Graphics graphics);

        //public abstract void Render(Graphics graphics);

        
    }
}
