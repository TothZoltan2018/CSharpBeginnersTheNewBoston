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
{
    //Part153 - Ref and Out Keywords
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age = 3; //A ref valtozonak erteket kell adni
            string Name; //Az out valtozonak nem kell
            Modify(ref age, out Name);
            MessageBox.Show(age.ToString() + ", " + Name);
        }

        void Modify(ref int age, out string Name)
        {
            age += 5;
            Name = "Zolika";
        }
    }
}