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
    //Part84 Timer Control
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int i = 11;

        //A Formon s timer1-en besllitottuk s tick idot, ami 1000ms
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Stop();
            //MessageBox.Show("1 sec elapsed.");
            i--;
            textBox1.Text = i.ToString();
            if (i == 0) timer1.Stop();
        }
    }
}