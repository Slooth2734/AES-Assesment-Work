using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    abstract class Shape : GraphicsHandler
    {
        /// <summary>
        ///     A shape constructer that specifies, all shapes
        ///     that inherit from this need to have these three
        ///     parameters as a minimum
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Shape(Color color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///     A mehtod that will be used to draw an outline of
        ///     each shape that inherits from the shape class
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(Graphics graphics);

        /// <summary>
        ///     A mehtod that will be used to draw a solid filled
        ///     version of each shape that inherits from the shape 
        ///     class
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Fill(Graphics graphics);

        //public abstract void Render(Graphics graphics);

        
    }
}
