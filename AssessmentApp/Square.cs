using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    class Square : Shape
    {
        GraphicsHandler GraphicsHandlerInstance;
        public static readonly int DeafultSide = 30;
        internal int Side { get; set; }

        /// <summary>
        ///     The square object that is created as a template for future
        ///     square to created in line with.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x">X coordinate of the top left corner</param>
        /// <param name="y">Y coordinate of the top left corner</param>
        /// <param name="width">Width of the rectnagle</param>
        /// <param name="height">Height of the rectnagle</param>
        public Square(Color color, int x, int y, int side)
        {
            this.Side = side;
        }

        /// <summary>
        ///     Draw command for the square shape class.
        ///     If no size peramiters are specified, the outline of a deafult 
        ///     sized square will be drawn at the given coordiantes. If no
        ///     coordinates are specified it will be drawn at the last saved 
        ///     value of x and y, if these have not been set yet they will 
        ///     automatically be 0, 0.
        ///     If the side length is given, the square will be drawn using the 
        ///     given side length rather than the deafult.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            Pen p = new Pen(graphicsHandler.color, 2);
            if (Side == 0)
            { graphics.DrawRectangle(p, graphicsHandler.x, graphicsHandler.y, DeafultSide, DeafultSide); }
            else
            { graphics.DrawRectangle(p, graphicsHandler.x, graphicsHandler.y, Side, Side); }
        }

        /// <summary>
        ///     Fill command for the square shape class.
        ///     If no size peramiters are specified, a solid filled, deafult 
        ///     sized rectangle will be drawn at the given coordiantes. If no
        ///     coordinates are specified it will be drawn at the last saved 
        ///     value of x and y, if these have not been set yet they will 
        ///     automatically be 0, 0.
        ///     If the side length is given, the square will be drawn 
        ///     using the given side length rather than the deafult.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Fill(Graphics graphics)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            SolidBrush b = new SolidBrush(graphicsHandler.color);
            if (Side == 0)
            { graphics.FillRectangle(b, graphicsHandler.x, graphicsHandler.y, DeafultSide, DeafultSide); }
            else
            { graphics.FillRectangle(b, graphicsHandler.x, graphicsHandler.y, Side, Side); }   
        }
    }
}
