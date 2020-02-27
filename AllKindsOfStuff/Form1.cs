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

namespace AllKindsOfStuff
{    //Part144 - Goto Keyword and Regions
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region endless loop with gotos
            goto MyCode;
        LabelBeforeSwitch:
            {
                string Zoli = "bbbbbbb";
                switch (Zoli)
                {
                    case "Zoli":
                        MessageBox.Show("Hello");
                        break;
                    default:
                        MessageBox.Show("The default");
                        goto case "Zoli";
                }
            }
        MyCode:
        //{} nem szukseges
                MessageBox.Show("This is printed at label MyCode");
                goto LabelBeforeSwitch;
            
            #endregion
        }
    }
}