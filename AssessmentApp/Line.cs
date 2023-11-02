using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    internal class Line : Shape
    {
        public Line(Color colour, int x, int y) : base(colour, x, y) { }

        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        // This will not be implemented due to being unable to
        // fill a line
        public override void Fill(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
