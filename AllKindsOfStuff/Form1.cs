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
    //Part147 - Checking Controls on Leave

    //Form Property: KeyPreview: True   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        //Ha egy masik kontrol lesz kivalasztva
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("You must provide a name!");
                textBox1.Select();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            //Ha a Country van kiválasztva...
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You must Select a Country!");
                comboBox1.Select();
            }
        }
    }
}