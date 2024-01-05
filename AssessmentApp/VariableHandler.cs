using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class VariableHandler
    {
        public int Radius { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Side { get; set; }
        public int Count { get; set; }
        public bool ExecuteFlag { get; set; }
        public bool LoopFlag { get; set; }
        public int LoopVal { get; set; }

        private static VariableHandler? variableHandlerInstance;

        /// <summary>
        ///     The constructor for the variable handler that is used by
        ///     the getInstance method.
        /// </summary>
        /// <param name="Radius"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Side"></param>
        /// <param name="Count"></param>
        /// <param name="executeFlag"></param>
        private VariableHandler(int Radius, int Width, int Height, int Side, int Count, bool executeFlag, bool loopFlag, int loopVal)
        {
            this.Radius = Radius;
            this.Width = Width;
            this.Height = Height;
            this.Side = Side;
            this.Count = Count;
            this.ExecuteFlag = executeFlag;
            this.LoopFlag = loopFlag;
            LoopVal = loopVal;  
        }

        /// <summary>
        ///     Creating the instance of the variable handler whenever one is not
        ///     or is reset to null.
        ///     This instance is the default values for each of the available
        ///     variable names. They are not set be default.
        /// </summary>
        /// <returns>An instance of the variable handler</returns>
        public static VariableHandler getInstance()
        {
            variableHandlerInstance ??= new VariableHandler(0, 0, 0, 0, 0, true, false, 0);
            return variableHandlerInstance;
        }

    }

}
