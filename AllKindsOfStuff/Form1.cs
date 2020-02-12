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
    //Part81 ColorDialog, 82ColorStruct
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Part81 ColorDialog
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true; //A megnyilo szinvalaszto ablakban rogton lathato a custom szinvalasztas.
            //cd.AllowFullOpen = false;//A megnyilo szinvalaszto ablakban valaszthatunk -e custom szint.
            cd.HelpRequest += Cd_HelpRequest;
            cd.ShowHelp = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = cd.Color;

                //82ColorStruct
                Color c = cd.Color;
                if (c.IsNamedColor) MessageBox.Show(c.Name);
                if (c.IsKnownColor) MessageBox.Show(c.ToKnownColor().ToString()); //Ezeket foleg a Windows hasznalja, pl. scrollbar

                c = Color.MintCream;
                MessageBox.Show(c.Name);
                c = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                MessageBox.Show(c.ToKnownColor().ToString()); //Igy is jo volt: MessageBox.Show(c.Name);
                MessageBox.Show(c.ToArgb().ToString("x"));

                int i = c.ToArgb();
                Color col = Color.FromArgb(i);
                button1.BackColor = col; // = c
                
            }
        }

        private void Cd_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("Choose the backgroundcolor of your button.");
        }
    }
}