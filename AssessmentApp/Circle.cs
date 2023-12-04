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
        public Circle(int radius)
        { 
            this.Radius = radius;
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
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            Pen p = new Pen(graphicsHandler.color, 2);
            if (Radius == 0 )
            { graphics.DrawEllipse(p, graphicsHandler.x, graphicsHandler.y, DeafultRadius * 2, DeafultRadius * 2); }
            else
            { graphics.DrawEllipse(p, graphicsHandler.x, graphicsHandler.y, Radius * 2, Radius * 2); }
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
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            SolidBrush b = new SolidBrush(graphicsHandler.color);
            if (Radius == 0)
            { graphics.FillEllipse(b, graphicsHandler.x, graphicsHandler.y, DeafultRadius * 2, DeafultRadius * 2); }
            else
            { graphics.FillEllipse(b, graphicsHandler.x, graphicsHandler.y, Radius * 2, Radius * 2); }
        }
    }
}
