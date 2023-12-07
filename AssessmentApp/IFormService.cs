using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class IFormService
    {
        private readonly IGraphicsAdapter _graphicsAdapter;
        private readonly ITestableForm _callingForm;
        private readonly IShapeFactory _shapeFactory;
        private readonly ITextBoxAdapter _textBoxAdapter;

        /// <summary>
        ///     A service class for the windows form that is responsible for 
        ///     managing the interactions between the testable form interface, 
        ///     graphics adapter interface, shape factory class, and text box 
        ///     adapter interface.
        /// </summary>
        /// <param name="callingForm"></param>
        /// <param name="graphicsAdapter"></param>
        /// <param name="shapeFactory"></param>
        /// <param name="textBoxAdapter"></param>
        public IFormService(ITestableForm callingForm, IGraphicsAdapter graphicsAdapter, IShapeFactory shapeFactory, ITextBoxAdapter textBoxAdapter)
        {
            _callingForm = callingForm;
            _graphicsAdapter = graphicsAdapter;
            _shapeFactory = shapeFactory;
            _textBoxAdapter = textBoxAdapter;
        }

        /// <summary>
        ///     Method used to call the draw method of a
        ///     specified shape type
        /// </summary>
        /// <param name="shapeType"></param>
        public void DrawShape(string shapeType)
        {
            Shape shape = _shapeFactory.getShape(shapeType);
            shape.Draw(_graphicsAdapter.getGraphics());
        }

        /// <summary>
        ///     Method used to call the fill method of a 
        ///     specified shape type
        /// </summary>
        /// <param name="shapeType"></param>
        public void FillShape(string shapeType)
        {
            Shape shape = _shapeFactory.getShape(shapeType);
            shape.Fill(_graphicsAdapter.getGraphics());
        }

        /// <summary>
        ///     Method used to set the contents of the text box
        ///     on the form
        /// </summary>
        /// <param name="text"></param>
        public void SetTextBoxText(string text)
        {
            _textBoxAdapter.Text = text;
        }

        /// <summary>
        ///     Method used to retrieve the current text in
        ///     the text box on the form
        /// </summary>
        /// <returns></returns>
        public string GetTextBoxText()
        {
            return _textBoxAdapter.Text;
        }

        /// <summary>
        ///     Method used to simulate opening the form
        /// </summary>
        public void OpenForm()
        {
            _callingForm.OpenForm();
        }

        /// <summary>
        ///     Method used to simulate closing the form
        /// </summary>
        public void CloseForm()
        {
            _callingForm.CloseForm();
        }
    }
}
