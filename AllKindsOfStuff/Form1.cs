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
    //Part103, 104 - Accessing All Controls
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Igy a groupControl-on belul nem nevezi at a gombot.
            //foreach (Control control in Controls)
            //{
            //    control.Text = "Zoli";
            //}

            //Ez a groupControl-on belul atnevezi a gombot
            AccessAll(Controls);
        }

        //Part103
        void AccessAll(Control.ControlCollection cc)
        {
            foreach (Control control in cc)
            {
                control.Text = "Zoli";

                if (control.HasChildren) AccessAll(control.Controls); //Rekurzioval bejarja a belso kontrollokat (itt groupBox1)

                //104
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;                 
                    checkBox.Checked = true;
                }

                if (control is Button)
                {
                    //control.Enabled = false;
                    Button butt = control as Button;
                    butt.Click += Butt_Click;
                }
            }
        }

        private void Butt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked some Button.");
        }
    }
}