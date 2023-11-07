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

        /// <summary>
        ///     The circle object that is created as a template for future
        ///     cirlces to created in line with.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        public Circle(Color color, int x, int y, int radius) : base(color, x, y) 
        { 
            this.color = color;
            this.Radius = Radius;
        }

        /// <summary>
        ///     Draw command for the cirlce shape class.
        ///     If no size peramiters are specified, the outline of a deafult 
        ///     sized circle will be drawn at the given coordiantes. If no
        ///     coordinates are specified it will be drawn at the last saved 
        ///     value of x and y, if these have not been set yet they will 
        ///     automatically be 0, 0.
        ///     If a radius is given, the circle will be drawn using the given
        ///     radius rather than the deafult.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            Pen p = new Pen(Color.Black, 2);
            if (Radius == 0 )
            { graphics.DrawEllipse(p, x, y, DeafultRadius * 2, DeafultRadius * 2); }
            else
            { graphics.DrawEllipse(p, x, y, Radius * 2, Radius * 2); }
        }

        /// <summary>
        ///     Fill command for the cirlce shape class.
        ///     If no size peramiters are specified, a solid filled, deafult 
        ///     sized circle will be drawn at the given coordiantes. If no
        ///     coordinates are specified it will be drawn at the last saved 
        ///     value of x and y, if these have not been set yet they will 
        ///     automatically be 0, 0.
        ///     If a radius is given, the circle will be drawn using the given
        ///     radius rather than the deafult.
        /// </summary>
        /// <param name="graphics"></param>
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
