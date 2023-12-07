using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class GraphicsHandler
    {
        public Color color {get; set;}
        public int x { get; set;}
        public int y { get; set;}
        public bool? onOff {get; set;}

        private static GraphicsHandler? graphicsHandlerInstance;
        
        /// <summary>
        ///     The constructor for the graphics handler that is used by
        ///     the getInstance method.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="onOff"></param>
        private GraphicsHandler(Color color, int x, int y, bool onOff) 
        {
            this.color = color;
            this.x = x;
            this.y = y;
            this.onOff = onOff;
        }

        /// <summary>
        ///     Creating the instance of the graphics handler whenever one is not
        ///     or is reset to null.
        ///     This instance is the default position and color and fill setting 
        ///     of any shape that will be drawn before they are changed.
        /// </summary>
        /// <returns>The instance of the graphics settings</returns>
        public static GraphicsHandler getInstance()
        {
            graphicsHandlerInstance ??= new GraphicsHandler(Color.Black, 0, 0, false);
            return graphicsHandlerInstance;
        }
        
    }
}