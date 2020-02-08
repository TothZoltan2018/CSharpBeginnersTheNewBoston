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
    //Part66, Par67, Part68 Bitwise operators
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Part66 ~ Invert operator
            short myshort = ~3;
            //Part67, Part68
            myshort = 3 & 5;// |, ^ 
            myshort = 5 >> 1; // 101 >> 1 = 10
            myshort = 5 << 2; // 101 << 2 = 10100
            MessageBox.Show(Convert.ToString(myshort, 2));
        }
    }
}