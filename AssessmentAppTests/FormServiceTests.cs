using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AssessmentApp.Tests
{
    [TestClass()]
    public class FormServiceTests
    {
        private Mock<ITestableForm> _callingForm;
        private Mock<IGraphicsAdapter> _graphicsAdapter;
        private Mock<IShapeFactory> _iShapeFactory;
        private Mock<ITextBoxAdapter> _textBoxAdapter;
        private ShapeFactory _shapeFactory;
        private IFormService _formService;
        private string _textBoxAdapterText;

        /// <summary>
        ///     Test method that initializes all of the variables that 
        ///     are to be mock tested in later tests.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _callingForm = new Mock<ITestableForm>();
            _graphicsAdapter = new Mock<IGraphicsAdapter>();
            _iShapeFactory = new Mock<IShapeFactory>();
            _textBoxAdapter = new Mock<ITextBoxAdapter>();
            _textBoxAdapter.SetupSet(box => box.Text = It.IsAny<string>())
                .Callback<string>(value => _textBoxAdapterText = value);

            _formService = new IFormService(_callingForm.Object, _graphicsAdapter.Object,
                _iShapeFactory.Object, _textBoxAdapter.Object);
        }

        /// <summary>
        ///     Test of the draw shape method in the form service. A valid
        ///     command in mixed case is used to see if the service is
        ///     able to correctly format the string and then return the 
        ///     correct shape as specified.
        /// </summary>
        [TestMethod]
        public void DrawShapeTest_LowerCaseValidCommand_ReturnsCorrectShape()
        {
            //arrange
            _iShapeFactory.Setup(factory => factory.getShape(It.IsAny<string>()))
                .Returns(Mock.Of<Shape>());

            //act
            _formService.DrawShape("cIrCLe");

            //assert
            _iShapeFactory.Verify(factory => factory.getShape("cIrCLe"));
            _graphicsAdapter.Verify(adapter => adapter.getGraphics());
        }
        /// <summary>
        ///     Test of the fill shape method in the form service. A valid
        ///     command in all upper case is used to see if the service is
        ///     able to correctly format the string and then return the 
        ///     correct shape as specified.
        /// </summary>
        [TestMethod]
        public void FillShapeTest_UpperCaseValidCommand_ReturnsCorrectShape()
        {
            //arrange
            _iShapeFactory.Setup(factory => factory.getShape(It.IsAny<string>()))
                .Returns(Mock.Of<Shape>());

            //act
            _formService.FillShape("RECTANGLE");

            //assert
            _iShapeFactory.Verify(factory => factory.getShape("RECTANGLE"));
            _graphicsAdapter.Verify(adapter => adapter.getGraphics());
        }
        /// <summary>
        ///     Test of the shape factory method getShape where the string that
        ///     is parsed is not an optional shape so the exeptin at the end of
        ///     the swtich case is thrown.
        /// </summary>
        [TestMethod]
        public void ShapeFactoryTest_NonShapeTypePasrsed_ThrowsException()
        {
            //arrange
            _iShapeFactory.Setup(factory => factory.getShape(It.IsAny<string>()))
                .Returns(Mock.Of<Shape>());

            //act and assert
            Assert.ThrowsException<NullReferenceException>(() => _shapeFactory.getShape("LEGO"));
        }
        /// <summary>
        ///     Test to see if the contents of a text box on the form is
        ///     set correctly as expected. Done using mocking.
        /// </summary>
        [TestMethod]
        public void SetTextBoxText_SetsTextCorrectly()
        {
            //arrange
            const string expectedText = "TestText";

            //act
            _formService.SetTextBoxText(expectedText);

            //assert
            _textBoxAdapter.VerifySet(adapter => adapter.Text = expectedText);
        }
        /// <summary>
        ///     Test to see if the contents of a text box on the form is
        ///     able to be read correctly by the form. Done using mocking.
        /// </summary>
        [TestMethod]
        public void GetTextBoxText_GetsTextCorrectly()
        {
            //arrange
            const string expectedText = "TestText";
            _textBoxAdapter.SetupGet(adapter => adapter.Text).Returns(expectedText);

            //act
            var actualText = _formService.GetTextBoxText();

            //assert
            Assert.AreEqual(expectedText, actualText);
        }
        /// <summary>
        ///     Test to see if the form opens correctly by using
        ///     mocking.
        /// </summary>
        [TestMethod]
        public void OpenForm_CallsCorrectMethod()
        {
            //act
            _formService.OpenForm();

            //assert
            _callingForm.Verify(form => form.OpenForm());
        }
        /// <summary>
        ///     Test to see if the form closes correctly by using
        ///     mocking.
        /// </summary>
        [TestMethod]
        public void CloseForm_CallsCorrectMethod()
        {
            //act
            _formService.CloseForm();

            //assert
            _callingForm.Verify(form => form.CloseForm());
        }
    }
}