using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AllKindsOfStuff
{
    //Part90 ProgressBar Control
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.
            //progressBar1.Style = ProgressBarStyle.Blocks;
            //progressBar1.Value += 10; //Ha tullepi a Max ereket, akkor exception
            //progressBar1.PerformStep();

            //2. Ha nem tudjuk, h valami meddig tart, igy jelezzuk.
            //progressBar1.Style = ProgressBarStyle.Marquee;
            //progressBar1.MarqueeAnimationSpeed = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1.
            //progressBar1.Value = progressBar1.Minimum;

            //2. leallitjuk, es eltuntetjuk a zold csikot: masik stilust valasztunk
            progressBar1.Style = ProgressBarStyle.Blocks;
        }
    }
}