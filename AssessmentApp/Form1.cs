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
        readonly Bitmap OutputBitmap;
        public Graphics graphics;
        public Form1()
        {
            InitializeComponent();

            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            graphics = Graphics.FromImage(pictureBox1.Image);
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        private void CommandWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            else
            {
                button1_Click(sender, e);
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            Parser.ParseLine(input);

            
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