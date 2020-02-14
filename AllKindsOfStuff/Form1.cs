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
    //Part98 Save Project Settings.
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            //A menuben felvenni az elmentendo valtozokat: Project-->AllKindsOfStuff Properties --> Settings
            //Visszaolvasas
            textBox1.Text = AllKindsOfStuff.Properties.Settings.Default.nameTobePreserved;
            textBox2.Text = AllKindsOfStuff.Properties.Settings.Default.ageTobePreserved.ToString();
            button1 = AllKindsOfStuff.Properties.Settings.Default.myButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kimentes
            AllKindsOfStuff.Properties.Settings.Default.nameTobePreserved = textBox1.Text;
            AllKindsOfStuff.Properties.Settings.Default.ageTobePreserved = Convert.ToInt32(textBox2.Text);
            AllKindsOfStuff.Properties.Settings.Default.myButton = button1;

            AllKindsOfStuff.Properties.Settings.Default.Save();
        }
    }
}