using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Rectangle : Shape
    {
        public static readonly int DeafultHeight = 50;
        public static readonly int DeafultWidth = 30;
        internal int Height { get; set; }
        internal int Width { get; set; }

        public Rectangle() : this(DeafultHeight, DeafultWidth)
        {
            Rectangle rectangle = new Rectangle(Position, DeafultHeight, DeafultHeight);
        }

        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public Rectangle(Point position, int height, int width) : base(position)
        {
            Height = height;
            Width = width;
        }

        public void Draw(Graphics graphics) 
        { 
            Graphics.FillRectangle(DeafultBrush, Rectangle());
        }

        public void Fill(Graphics graphics)
        {

        }

        public Rectangle(IEnumerable<int> arguments)
        {

        }
    }
}
