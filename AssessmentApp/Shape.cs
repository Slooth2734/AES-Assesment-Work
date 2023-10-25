using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Shape
    {
        Form form = new Form1();
        public Brush DeafultBrush = Brushes.Black;
        public Point DeafultPosition = new Point();
        public Point Position {  get; set; }
        public int height;
        public int width;

        public Shape() { }

        public void Draw(Graphics graphics) { }

        public void Fill(Graphics graphics) { }

        public void Render(Graphics graphics) { }

        public Shape(Point position) 
        {
            Position = position;
        }
    }
}
