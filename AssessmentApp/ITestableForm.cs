using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    /// <summary>
    ///     Interface establishing the methods that need
    ///     to be used by the class that inherits form it.
    /// </summary>
    public interface ITestableForm
    {
        void OpenForm();
        void CloseForm();
    }

    /// <summary>
    ///     Class that inherits from the interface that
    ///     simulates an intance of the form being created.
    /// </summary>
    public class TestableForm : ITestableForm
    {
        private readonly Form _form;
        public TestableForm(Form form)
        {
            _form = form;
        }
        public void OpenForm()
        {
            _form.Show();
        }
        public void CloseForm()
        {
            _form.Close();
        }
    }
}
