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
        GraphicsHandler GraphicsHandlerInstance;
        static int DeafultHeight = 50;
        static int DeafultWidth = 30;
        internal int Height { get; set; }
        internal int Width { get; set; }

        /// <summary>
        ///     The rectangle object that is created as a template for future
        ///     rectangles to created in line with.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x">X coordinate of the top left corner</param>
        /// <param name="y">Y coordinate of the top left corner</param>
        /// <param name="width">Width of the rectnagle</param>
        /// <param name="height">Height of the rectnagle</param>
        public Rectangle(Color color, int x, int y, int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Draw command for the rectangle shape class.
        ///     If no size peramiters are specified, the outline of a deafult 
        ///     sized rectangle will be drawn at the given coordiantes. If no
        ///     coordinates are specified it will be drawn at the last saved 
        ///     value of x and y, if these have not been set yet they will 
        ///     automatically be 0, 0.
        ///     If the width and heigh are given, the rectangle will be drawn 
        ///     using the given width and heigh rather than the deafult.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            Pen p = new Pen(graphicsHandler.color, 2);
            if (Height == 0 || Width == 0)
            { graphics.DrawRectangle(p, graphicsHandler.x, graphicsHandler.y, DeafultWidth, DeafultHeight); }
            else
            { graphics.DrawRectangle(p, graphicsHandler.x, graphicsHandler.y, Width, Height); }
        }

        /// <summary>
        ///     Fill command for the rectangle shape class.
        ///     If no size peramiters are specified, a solid filled, deafult 
        ///     sized rectangle will be drawn at the given coordiantes. If no
        ///     coordinates are specified it will be drawn at the last saved 
        ///     value of x and y, if these have not been set yet they will 
        ///     automatically be 0, 0.
        ///     If the width and heigh are given, the rectangle will be drawn 
        ///     using the given width and heigh rather than the deafult.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Fill(Graphics graphics)
        {
            GraphicsHandler graphicsHandler = GraphicsHandler.getInstance();
            SolidBrush b = new SolidBrush(graphicsHandler.color);
            if (Height == 0 || Width == 0)
            { graphics.FillRectangle(b, graphicsHandler.x, graphicsHandler.y, DeafultWidth, DeafultHeight); }
            else
            { graphics.FillRectangle(b, graphicsHandler.x, graphicsHandler.y, Width, Height); }
        }
    }
}
