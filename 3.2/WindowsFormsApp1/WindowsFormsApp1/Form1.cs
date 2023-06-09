using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width, pictureBox1.Height);
        }

        int _x;
        int _y;
        bool _mouseClicked = false;

        Color SelectedColor
        {
            get => colorDialog1.Color; 
        }

        int SelectedSize
        {
            get { return brushSize.Value; }
        }
        Brush _selectedBrush;

        Color DefaultColor
        {
            get { return Color.White; }
        }

        void CreateBlank(int width, int height)
        {
            var oldImage = pictureBox1.Image;

            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;

            if (oldImage != null)
            {
                oldImage.Dispose();
            }

            Brush.W = width;
            Brush.H = height;

        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
        }

        private void btnSircle_Click(object sender, EventArgs e)
        {
            _selectedBrush = new SolidBrush(SelectedColor, SelectedSize);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedBrush == null)
            {
                return;
            }
            _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
            pictureBox1.Refresh();
            _mouseClicked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X > 0 ? e.X : 0;
            _y = e.Y > 0 ? e.Y : 0;

            if (_mouseClicked)
            {
                _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
                pictureBox1.Refresh();
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateImage create = new CreateImage();
            create.ShowDialog();
            if (create.Canceled == true)
            {
                CreateBlank(create.W, create.H);
                
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void brnSquare1_Click(object sender, EventArgs e)
        {
            _selectedBrush = new CirclestBrush(SelectedColor,SelectedSize);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm aboutProgramm = new AboutProgramm();
            aboutProgramm.ShowDialog();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            _selectedBrush = new Clear(SelectedColor, SelectedSize);
        }

        private void colorDialog1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }
    }
}
