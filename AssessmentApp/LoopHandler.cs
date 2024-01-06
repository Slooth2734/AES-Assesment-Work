using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class LoopHandler
    {
        public bool ExecuteFlag { get; set; }
        public bool LoopFlag { get; set; }
        public int LoopVal { get; set; }
        public int LineNum { get; set; }

        private static LoopHandler? loopHandlerInstance;

        /// <summary>
        ///     The constructor for the loop handler that is used by
        ///     the getInstance method.
        /// </summary>
        /// <param name="executeFlag"></param>
        /// <param name="loopFlag"></param>
        /// <param name="loopVal"></param>
        /// <param name="lineNum"></param>
        private LoopHandler(bool executeFlag, bool loopFlag, int loopVal, int lineNum)
        {
            this.ExecuteFlag = executeFlag;
            this.LoopFlag = loopFlag;
            LoopVal = loopVal;
            LineNum = lineNum;
        }

        /// <summary>
        ///     Creating the instance of the loop handler whenever one is not
        ///     or is reset to null.
        ///     This instance is the default values for each of the loop 
        ///     condition.
        /// </summary>
        /// <returns></returns>
        public static LoopHandler getInstance()
            {
                loopHandlerInstance ??= new LoopHandler(true, false, 0, 0);
                return loopHandlerInstance;
            }
    }
}
