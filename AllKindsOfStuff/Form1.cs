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
using System.Collections;

namespace AllKindsOfStuff
{
    //Part197 - IDisposable pt 1
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.BinaryReader br = new System.IO.BinaryReader(System.IO.File.OpenRead(""));
            br.Dispose(); //Calls the destructor
        }
    }

    class MyClass
    {
        public MyClass()
        {
            MessageBox.Show("I am the constructor.");
        }

        ~MyClass()
        {
            MessageBox.Show("I am the destructor.");
        }
    }
}