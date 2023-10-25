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
        
        }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public Circle(Point position, int radius) : base(position) 
        {
            Radius = radius;
        }

        public Circle(IEnumerator<int> arguments)
        {

        }
        public void Draw(Graphics graphics)
        {
        }
        public void Fill(Graphics graphics)
        {

        }
    }
}
