using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentApp
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private readonly Parser parser;
        private readonly IFormService _formService;
        private readonly ITextBoxAdapter _textBoxAdapter;

        /// <summary>
        ///     The maine form object that is used to instialize the form
        ///     to be used by the user
        /// </summary>
        /// <param name="parser"></param>
        public Form1(Parser parser)
        {
            this.parser = parser;
            InitializeComponent();

            pictureBox1.Image ??= new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
        }

        /// <summary>
        ///     Mehtod that activates the Draw button once enter is clicked
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e"></param>
        private void CommandWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            { return; }
            else if (e.KeyCode == Keys.Enter)
            { button1_Click(sender, e); }
        }

        /// <summary>
        ///     The Draw button that once clicked, checks to see which text box has
        ///     a commmand(s) in and then passes the given text to the parser class.
        ///     If both text boxes are found to contain text, then an exception will
        ///     be thrown and nothing will happen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The event</param>
        public void button1_Click(object sender, EventArgs e)
        {
            var lineTyped = textBox1.Text.Trim().ToLower();
            var programTyped = textBox2.Text.Trim().ToLower();

            // When text is entered in the mulit-line box
            if (lineTyped == null || lineTyped == "")
            {
                try
                {
                    IEnumerable<Command> command = parser.ParseProgram(textBox2.Text, graphics);
                }
                catch (Exception ex)
                {
                    textBox2.Text = "There was a syntax error. Perhaps check syntax before running the program";
                }
            }
            // When text is entered in the single-line box
            else if (programTyped == null || programTyped == "")
            {
                try
                {
                    Command coammand = parser.ParseLine(textBox1.Text, graphics);
                }
                catch (Exception ex)
                {
                    textBox1.Text = "There was a syntax error. Perhaps check syntax before running the program";
                }
            }
            else if (programTyped != null || programTyped != "" && lineTyped != null || lineTyped != "")
            {
                textBox3.Text = ($"ERROR: Both text boxes cannot contian commands at the same time");
            }
            else
            {
                textBox3.Text = "Try entering a command and then hitting run to see what it does! If your not sure how to draw something, try hitting the help button.";
            }
            textBox1.Text = "";
            Refresh();
        }

        /// <summary>
        ///     Syntax button that uses syntax checking methods to see if the
        ///     proposed command is valid in every form adn repost back if it is
        ///     or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void button2_Click(object sender, EventArgs e)
        {
            var lineTyped = textBox1.Text.Trim().ToLower();
            var programTyped = textBox2.Text.Trim().ToLower();

            textBox3.Text = "";

            // When text is entered in the mulit-line box
            if (lineTyped == null || lineTyped == "")
            {
                string[] lines = programTyped.Split('\n');
                foreach (var line in lines)
                {
                    try
                    {
                        bool syntax = parser.CheckSyntax(line);
                        if (syntax == false)
                        {
                            textBox3.Text = "";
                            textBox3.Text = ("All program syntax is valid");
                        }
                    }
                    catch (Exception ex)
                    {
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox3.Text = (line + ": " + ex.Message);
                    }
                }
            }
            // When text is entered in the single-line box
            else if (programTyped == null || programTyped == "")
            {
                try
                {
                    bool syntax = parser.CheckSyntax(textBox1.Text);
                    if (syntax == false)
                    {
                        textBox3.Text = "";
                        textBox3.Text = (lineTyped + ": Is valid syntax");
                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox3.Text = (lineTyped + ": " + ex.Message);
                }
            }
        }

        // Single line text box
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Mulit-line text box
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Output text box
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // main drawing picture box
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Save Button
        private void button3_Click(object sender, EventArgs e)
        {
            Save(textBox2.Text);
        }

        //Load Button
        private void button4_Click(object sender, EventArgs e)
        {
            Load(textBox2.Text);
        }

        // Clear Button
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            Refresh();
        }

        /// <summary>
        ///     This is the code for the help button on the form. This is used to launch
        ///     the help form that will inform users of how to use the initial drwaing 
        ///     form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 helpForm = new Form2();
            helpForm.ShowDialog();
        }

        /// <summary>
        ///     Method used by the Load button to open a text file with commands.
        ///     This code was inspidered by code generate by ChatGPT
        /// </summary>
        /// <param name="text"></param>
        public new void Load(string text)
        {
            var openFileDialoge = new OpenFileDialog
            {
                Filter = "Text Files | *.txt| ALL Files | *.*"
            };

            if (openFileDialoge.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (openFileDialoge.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialoge.FileName;
                try
                {
                    string fileContents = File.ReadAllText(filePath);

                    textBox2.Text = fileContents;
                }
                catch (Exception ex)
                {
                    textBox2.Text = $"ERROR: {ex.Message} error";
                }
            }
        }

        /// <summary>
        ///     Method used by the Save button to open the file explorer and allow the
        ///     user to save the file with the contents of the multi line text box as 
        ///     a .txt file. The user can also change the name of the file here to avoid
        ///     saving over the same file.
        /// </summary>
        /// <param name="text">The contents of the multi-line text box</param>
        public void Save(string text)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "program.txt",
                Filter = @"Text File | *.txt"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var writer = new StreamWriter(saveFileDialog.OpenFile());
            WriteToFile(writer, text);
        }

        /// <summary>
        ///     Method that is used by the Save() method to help the contents of the 
        ///     multi-line text box be written to a file.
        /// </summary>
        /// <param name="writer">The writer of the file</param>
        /// <param name="text">The contents of the multi-line text box</param>
        /// <exception cref="IOException">If the file is unable to be written, the exception is thrown</exception>
        public void WriteToFile(StreamWriter writer, string text)
        {
            try
            {
                text.Split('\n').ToList().ForEach(writer.WriteLine);
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while saving the program to file system: {ex.Message}");
            }
            finally
            {
                writer.Dispose();
                writer.Close();
            }
        }
    }
}