using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;

namespace AllKindsOfStuff
{    //Part145 - Capturing Screen
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Screenshot);
            t.Start();
        }

        void Screenshot()
        {
            for (; ; ) //endless loop
            {
                //Ebben taroljuk majd a screen capture-t
                Bitmap b = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                //Ez fogja kirajzolni a screen capture-t
                Graphics g = Graphics.FromImage(b);
                //Ez csinalja a screen capture-t a Bitmap b-be
                g.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.WorkingArea.Size);
                //Megjelenitjuk a pictureBox-ban
                pictureBox1.Image = b;
            }
        }
    }
}