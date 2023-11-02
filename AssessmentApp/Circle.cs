using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentApp
{
    class Circle : Shape
    {
        protected int DeafultRadius = 30;
        internal int Radius { get; set; }

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y) 
        { 
            this.Radius = Radius;
        }
        /*
        public Circle(int radius)
        {
            Radius = radius;
        }

        public Circle(Point position, int radius) : base(position) 
        {
            position.X = (base.CurrentPoint.X);
            position.Y = (base.CurrentPoint.Y);
            Radius = radius;
        }
        
        public Circle(IEnumerator<int> arguments)
        {
            //check if there are 1 or 3 ints
            //set the first tow ints to the position
            //set the second int to the radius
        }
        */
        public override void Draw(Graphics graphics)
        {
            Pen p = new Pen(Color.Black, 2);
            if (Radius == 0 )
            { graphics.DrawEllipse(p, x, y, DeafultRadius * 2, DeafultRadius * 2); }
            else
            { graphics.DrawEllipse(p, x, y, Radius * 2, Radius * 2); }
        }

        public override void Fill(Graphics graphics)
        {
            SolidBrush b = new SolidBrush(Color.Black);
            if (Radius == 0)
            { graphics.FillEllipse(b, x, y, DeafultRadius * 2, DeafultRadius * 2); }
            else
            { graphics.FillEllipse(b, x, y, Radius * 2, Radius * 2); }
        }
    }
}
