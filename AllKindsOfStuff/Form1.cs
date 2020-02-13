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
    //Part87 Multiple Forms
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ket pledanyt csinalunk a Form2-bol
            Form2 f = new Form2();
            f.Show();
            Form2 f2 = new Form2();
            f2.Show();
            //Nem kattinthatunk vissza a Form1-re, amig be nem zarjuk
            Form2 f3 = new Form2();
            f3.ShowDialog();

            Form2 f4 = new Form2("Sent form Form1");
            f4.ShowDialog();
        }
    }
}