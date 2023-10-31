using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Rectangle : Shape
    {
        static int DeafultHeight = 50;
        static int DeafultWidth = 30;
        internal int Height { get; set; }
        internal int Width { get; set; }

        public Rectangle()
        {

            //check if there are 2 or 4 ints
            //set the first int to the width
            //set the second int to the heihgt
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            if (Height == 0 || Width == 0)
            {
                graphics.DrawRectangle(pen, CurrentPoint.X, CurrentPoint.Y, DeafultWidth, DeafultHeight);
            }
            else
            {
                graphics.DrawRectangle(pen, CurrentPoint.X, CurrentPoint.Y, Width, Height);
            }
        }

        public override void Fill(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            if (Height == 0 || Width == 0)
            {
                graphics.FillRectangle(brush, CurrentPoint.X, CurrentPoint.Y, DeafultWidth, DeafultHeight);
            }
            else
            {
                graphics.FillRectangle(brush, CurrentPoint.X, CurrentPoint.Y, Width, Height);
            }
        }
    }
}
