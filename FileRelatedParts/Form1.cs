using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileRelatedParts
{
    //Part47- Is, as and Casting
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //example1
            //object myObj = "Zoli";
            //if (myObj is string) MessageBox.Show((string)myObj);

            //example2
            Control myControl = button1;
            if (myControl is Button)
            {
                //Button myButton = (Button)myControl;
                //A castolas alternativaja az "as" operator
                Button myButton = myControl as Button;
                MessageBox.Show(myButton.Text);
            }


            //example
            //example
            //example


        }
    }
}