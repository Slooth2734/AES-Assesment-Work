using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public abstract class Shape
    {
        public Point DeafultPoint = new Point(0, 0);
        public Point CurrentPoint {  get; set; }

        public Shape() {    }
        public Shape(Point position) 
        {
            CurrentPoint = position;
        }

        public abstract void Draw(Graphics graphics);

        public abstract void Fill(Graphics graphics);

        //public abstract void Render(Graphics graphics);

        
    }
}
