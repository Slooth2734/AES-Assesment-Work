using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        /// <summary>
        ///     Test of the write to a file method from the form class.
        ///     This test attempts to save one line to a file and 
        ///     compares what is saved to what the input is once it
        ///     has been processed through the method. Passes if the
        ///     method correctly makes the file and also if the contents
        ///     is the same as the input.
        /// </summary>
        [TestMethod()]
        public void WriteOneLineToFile()
        {
            //arrange
            var filePath = "test.txt";
            var text = "circle 100";

            using (var writer = new StreamWriter(filePath))
            {
                var form = new Form1(new Parser());
                //act
                form.WriteToFile(writer, text);
                //assert
                Assert.IsTrue(File.Exists(filePath));
                var fileContent = File.ReadAllText(filePath).Trim();
                Assert.AreEqual(text.Trim(), fileContent);
            }
        }
        /// <summary>
        ///     Test of the write to a file method from th form class.
        ///     This test attempts to save three line to a file and
        ///     compares what is saved to the input once it has been
        ///     porcessed thrught the method. Passes if the method 
        ///     correctly makes the file and also if the contents is 
        ///     the same as the input.
        /// </summary>
        [TestMethod()]
        public void WriteThreeLinesToFile()
        {
            //arrange
            var filePath = "test.txt";
            var text = "circle 100\ntriangle 20 350 200\nrectangle";

            using (var writer = new StreamWriter(filePath))
            {
                var form = new Form1(new Parser());
                //act
                form.WriteToFile(writer, text);
                //assert
                Assert.IsTrue(File.Exists(filePath));
                var fileContent = File.ReadAllText(filePath).Trim();

                /// Due to windows having platform specific new-line characters
                /// these two replace methods are needed other wise the test's
                /// assert.areEqual test will fail purly due to the new line 
                /// character being read differently
                text = text.Replace("\r\n", "\n");
                fileContent = fileContent.Replace("\r\n", "\n");
                //assert
                Assert.AreEqual(text.Trim(), fileContent);
            }
        }
        /// <summary>
        ///     Test of the write to a file method from th form class.
        ///     This test simulates the writer failing due to it being
        ///     closed while saving the file. An exception should be 
        ///     thrown under this circumstance.
        /// </summary>
        [TestMethod()]
        public void WriteToFile_withStreamWriterNotAvailable_throwsIOException()
        {
            //arrange
            var filePath = "test.txt";
            var text = "sqaure 10\nCIRCLE 40 30 30";

            using (var writer = new StreamWriter(filePath))
            {
                var form = new Form1(new Parser());
                //simulate and ecxception during writing
                writer.BaseStream.Close();
                //assert
                Assert.ThrowsException<IOException>(() => form.WriteToFile(writer, text));

            }
        }
    }
}