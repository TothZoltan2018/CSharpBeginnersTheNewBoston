#define Valami
//#undef Valami
#define Akarmi

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
using System.Xml;

namespace FileRelatedParts
{
    //Part178 - Preprocessor Directives
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Valami
            //
            //
            //
            #endregion

#if Valami
            MessageBox.Show("Valami is #defined");
#warning Valami is defined
#elif Akarmi
            MessageBox.Show("Valami is #defined");
#else
            MessageBox.Show("Semmi is #defined
#error Semmi is defined
#endif //Valami


        }
    }
}