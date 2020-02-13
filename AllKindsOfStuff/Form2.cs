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
    public partial class Form2 : Form
    {
        public Form2(string myString)
        {
            InitializeComponent();
            label1.Text = myString;
        }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
