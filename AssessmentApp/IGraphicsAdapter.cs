using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentApp
{
    /// <summary>
    ///     Interface establishing the methods that need
    ///     to be used by the class that inherits form it.
    /// </summary>
    public interface IGraphicsAdapter
    {
        Graphics getGraphics();
        void DrawRectangle(Pen p, int x, int y, int width, int height);
        void FillRectangle(Brush b, int x, int y, int width, int height);
        void DrawEllipse(Pen p, int x, int y, int width, int height);
        void FillEllipse(Brush b, int x, int y, int width, int height);
        void DrawLine(Pen p, int x, int y, int otherX, int otherY);
        void Clear(Color color);
    }

    /// <summary>
    ///     Class that inherits from the interface that
    ///     simulates all of the methods that would be
    ///     used on the real windows form, but on the
    ///     simulated version.
    /// </summary>
    public class GraphicsAdapter : IGraphicsAdapter
    {
        private readonly Graphics _graphics;
        public GraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        ///     Method to retrieve the current instance of graphics.
        /// </summary>
        /// <returns>The current instance of graphics</returns>
        public Graphics getGraphics()
        {
            return _graphics;
        }
        /// <summary>
        ///     Method used to simulate drawing of a rectangle outline
        ///     on the testable form.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(Pen p, int x, int y, int width, int height)
        {
            _graphics.DrawRectangle(p, x, y, width, height);
        }

        /// <summary>
        ///     Method used to simulate drawing of a filled in rectangle
        ///     on the testable form.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillRectangle(Brush b, int x, int y, int width, int height)
        {
            _graphics.FillRectangle(b, x, y, width, height);
        }

        /// <summary>
        ///     Method used to simulate drawing of a ellipse/circle 
        ///     outline on the testable form.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawEllipse(Pen p, int x, int y, int width, int height)
        {
            _graphics.DrawEllipse(p, x, y, width, height);
        }

        /// <summary>
        ///     Method used to simulate drawing of a filled in ellipse/circle
        ///     on the testable form.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillEllipse(Brush b, int x, int y, int width, int height)
        {
            _graphics.FillEllipse(b, x, y, width, height);
        }

        /// <summary>
        ///     Method usxed to simulate the drawing of a line on the
        ///     testable form.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="otherX"></param>
        /// <param name="otherY"></param>
        public void DrawLine(Pen p, int x, int y, int otherX, int otherY)
        {
            _graphics.DrawLine(p, x, y, otherX, otherY);
        }

        /// <summary>
        ///     Method used to simulate clearing the testable form.
        /// </summary>
        /// <param name="color"></param>
        public void Clear(Color color)
        {
            _graphics.Clear(color);
        }
    }
}
