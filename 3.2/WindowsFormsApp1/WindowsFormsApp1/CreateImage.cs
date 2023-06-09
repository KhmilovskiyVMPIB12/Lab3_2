using System;
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
    public partial class CreateImage : Form
    {
        public CreateImage()
        {
            InitializeComponent();
        }

        public int W
        {
            get
            {
                string text = tbWidth.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        public int H
        {
            get
            {
                string text = tbHeight.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }

        public string F
        {
            get
            {
                string text = tbFileName.Text;
                return text;
            }
        }

        bool _canceled = false;
        public bool Canceled
        {
            get => _canceled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _canceled = true;
            Close();
        }
    }
}
