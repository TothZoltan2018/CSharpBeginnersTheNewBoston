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
{    //Part146 - Making Keyboard Shortcuts

    //Form Property: KeyPreview: True   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode.ToString() == "Z")            
                MessageBox.Show("Key \"ALT\" + \"Z\" is pressed from the Form");            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode.ToString() == "T")
                MessageBox.Show("Key \"SHIFT\" + \"T\" is pressed from the TextBox");
        }
    }
}