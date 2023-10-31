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
        Pen pen = new Pen(Color.Black, 2);
        Brush brush = new SolidBrush(Color.Black);
        private readonly Parser parser;
        public Form1(Parser parser)
        {
            this.parser = parser;
            InitializeComponent();

            if (pictureBox1.Image == null)
            {   pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);  }
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
        ///     Draw Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            var commandTyped = textBox1.Text.Trim().ToLower();
            Command coammand = parser.ParseLine(textBox1.Text, graphics);

            textBox1.Text = "";
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}