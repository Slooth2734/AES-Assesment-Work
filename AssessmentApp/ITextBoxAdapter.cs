using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    /// <summary>
    ///     Interface establishing the methods that need
    ///     to be used by the class that inherits form it.
    /// </summary>
    public interface ITextBoxAdapter
    {
        string Text { get; set; }
    }

    /// <summary>
    ///     Class that inherits from the interface that
    ///     simulates setting up the text box on a form.
    /// </summary>
    public class TextBoxAdapter : ITextBoxAdapter 
    {
        private readonly TextBox _textBox;

        public TextBoxAdapter(TextBox textBox)
        {
            _textBox = textBox;
        }

        public string Text 
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }
    }

}
