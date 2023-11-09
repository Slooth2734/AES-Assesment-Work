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
        Graphics graphics;
        Pen p = new Pen(Color.Black, 2);
        Brush b = new SolidBrush(Color.Black);
        private readonly Parser parser;
        public bool onOff;
        public int currentX, currentY;
        public Form1(Parser parser)
        {
            this.parser = parser;
            InitializeComponent();

            if (pictureBox1.Image == null)
            { pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height); }
            graphics = Graphics.FromImage(pictureBox1.Image);
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImageUnscaled(pictureBox1.Image, 0, 0);
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
                throw new IOException($"ERROR: Both text boxes cannot contian commands at the same time");
            }
            textBox1.Text = "";
            Refresh();
        }

        /// <summary>
        ///     Syntaxt buttone that uses syntax checking methods to see if the
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

            // When text is entered in the mulit-line box
            if (lineTyped == null || lineTyped == "")
            {
                try
                {
                    bool syntax = parser.CheckSyntax(textBox2.Text);
                }
                catch (Exception ex)
                {
                    textBox2.Text = "";
                    textBox2.Text = (programTyped + ": " + ex.Message);
                }
            }
            // When text is entered in the single-line box
            else if (programTyped == null || programTyped == "")
            {
                try
                {
                    bool invalidSyntax = parser.CheckSyntax(textBox1.Text);
                }
                catch (Exception ex)
                {
                    textBox1.Text = "";
                    textBox1.Text = (lineTyped + ": " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

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
            Refresh();
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
        internal void WriteToFile(StreamWriter writer, string text)
        {
            try
            {
                text.Split('\n').ToList().ForEach(writer.WriteLine);
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while savoing the program to file system: {ex.Message}");
            }
            finally
            {
                writer.Dispose();
                writer.Close();
            }
        }
    }
}