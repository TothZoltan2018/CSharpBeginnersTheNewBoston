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
    //Part45
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int myInt = Convert.ToInt32(textBox1.Text); //from string to int
                MessageBox.Show(myInt.ToString()); //from int to string

                bool mybool = Convert.ToBoolean("true");
                MessageBox.Show(mybool.ToString());

                MessageBox.Show(Convert.ToInt32(3.678).ToString());

                //Es igy tovabb szinte mindenbol minedent a jozan esz hatarain belul.
            }
            catch
            {
                MessageBox.Show("Conversion failed.");
            }
        }
    }
}