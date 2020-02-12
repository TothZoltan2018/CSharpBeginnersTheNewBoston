using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AllKindsOfStuff
{
    //Part79 PictureBox
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //1.
                //pictureBox1.ImageLocation = ofd.FileName;

                //2.
                Image image = Image.FromFile(ofd.FileName);
                pictureBox1.Image = image;

                //3.
                //pictureBox1.ImageLocation = "https://www.google.hu/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
            }
        }
    }
}