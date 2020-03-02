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
    //Part166 - Optional Parameters
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Method overloading
            ShowMessage("Only one param");
            ShowMessage("Two params", "some title");

            //2. Dwfault values
            ShowMessage2("Only one param");
            ShowMessage2("Two params", "own title");
            ShowMessage2("Three params", "own title", 3);
        }

        //1.
        void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title);
        }

        void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        //2. (//Az opcionalis parameter(ek) az utolsok lehetnek csak.)
        void ShowMessage2(string message, string title = "Default value", int amount = 0) 
        {
            for (int i = 0; i < amount; i++)
                MessageBox.Show(message, title);                     
        }


    }
}