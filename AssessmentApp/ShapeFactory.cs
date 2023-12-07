using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public interface IShapeFactory
    {
        Shape getShape(string shapeType);
    }

    public class ShapeFactory : IShapeFactory
    {
        /// <summary>
        ///     Shape factory that creates and returns an instance of 
        ///     a shape based on the spacified shape type
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns>The instance of whichever shape is specified</returns>
        /// <exception cref="ArgumentException"></exception>
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToLower().Trim();

            switch (shapeType)
            {
                case "circle":
                    return new Circle();
                case "rectangle":
                    return new Rectangle();
                case "square":
                    return new Square();
                case "triangle":
                    return new Triangle();
                default:
                    throw new NullReferenceException($"FACTORY ERROR: Invalid shape type, {shapeType}");
            }
        }
    }
}
