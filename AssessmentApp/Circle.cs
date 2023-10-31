using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentApp
{
    public class Circle : Shape
    {
        public static readonly int DeafultRadius = 30;
        internal int Radius { get; set; }

        public Circle() : this(DeafultRadius) 
        { 
            Radius = DeafultRadius;
        }

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

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            if (Radius == 0 )
            {
                graphics.DrawEllipse(pen, CurrentPoint.X, CurrentPoint.Y, DeafultRadius, DeafultRadius);
            }
            else
            {
                graphics.DrawEllipse(pen, CurrentPoint.X, CurrentPoint.Y, Radius, Radius);
            }
        }

        public override void Fill(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            if (Radius == 0)
            {
                graphics.FillEllipse(brush, CurrentPoint.X, CurrentPoint.Y, DeafultRadius, DeafultRadius);
            }
            else
            {
                graphics.FillEllipse(brush, CurrentPoint.X, CurrentPoint.Y, Radius, Radius);
            }
        }
    }
}
