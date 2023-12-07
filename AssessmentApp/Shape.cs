using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public abstract class Shape
    {
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
