using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    internal class Line : Shape
    {
        GraphicsHandler GraphicsHandlerInstance;
        internal int otherX { get; set; }
        internal int otherY { get; set; }

        /// <summary>
        ///     The line object that is created as a template for future
        ///     lines to created in line with.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="otherX"></param>
        /// <param name="otherY"></param>
        public Line(Color color, int x, int y, int otherX, int otherY)
        {
            this.otherX = otherX;
            this.otherY = otherY;
        }

        /// <summary>
        ///     Draw command for the line shape class.
        ///     The line will only be drawn when 4 numbers are specified due 
        ///     to two coordinated being needed to know where to draw the line
        ///     to and from. If not, the line will not be drawn. The color will
        ///     use the stored color.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            Pen p = new Pen(graphicsHandler.color, 2);
            graphics.DrawLine(p, graphicsHandler.x, graphicsHandler.y, otherX, otherY);
        }

        /// <summary>
        ///     Fill command for the line shape class.
        ///     The line will only be drawn when 4 numbers are specified due 
        ///     to two coordinated being needed to know where to draw the line
        ///     to and from. If not, the line will not be drawn. The color will
        ///     use the stored color.
        ///     The fill method only dfferts to the draw method by making the
        ///     line much thicker.
        /// </summary>
        /// <param name="graphics"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Fill(Graphics graphics)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            Pen p = new Pen(graphicsHandler.color, 7);
            graphics.DrawLine(p, graphicsHandler.x, graphicsHandler.y, otherX, otherY);
        }
    }
}
