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
    //Part89 ComboBox Control
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ComboBox - readonly, ha a property-knel beallitjuk: DropDownList
            //if (comboBox1.Text == "Zolika") MessageBox.Show("Teszt");
            comboBox1.Items[0] = "Zolika baba";
            comboBox1.Items.Add("Arankamama");
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Egy elem ki lett valasztva.");
        }
    }
}