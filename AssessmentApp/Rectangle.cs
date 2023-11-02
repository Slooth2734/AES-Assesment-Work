using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    class Rectangle : Shape
    {
        static int DeafultHeight = 50;
        static int DeafultWidth = 30;
        internal int Height { get; set; }
        internal int Width { get; set; }

        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.Width = width;
            this.Height = height;
            //check if there are 2 or 4 ints
            //set the first int to the width
            //set the second int to the heihgt
        }

        public override void Draw(Graphics graphics)
        {
            Pen p = new Pen(Color.Black, 2);
            if (Height == 0 || Width == 0)
            { graphics.DrawRectangle(p, x, y, DeafultWidth, DeafultHeight);   }
            else
            { graphics.DrawRectangle(p, x, y, Width, Height); }
        }

        public override void Fill(Graphics graphics)
        {
            SolidBrush b = new SolidBrush(Color.Black);
            if (Height == 0 || Width == 0)
            { graphics.FillRectangle(b, x, y, DeafultWidth, DeafultHeight); }
            else
            { graphics.FillRectangle(b, x, y, Width, Height); }
        }
    }
}
