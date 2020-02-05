using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysAndStrings
{
    //Part49
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = "Wolfgang Amadeus Mozart";
            string FirstName = Name.Substring(0, 8);

            MessageBox.Show(FirstName);

        }
    }
}
