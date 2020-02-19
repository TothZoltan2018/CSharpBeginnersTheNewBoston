using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;//

namespace AllKindsOfStuff
{
    //118 - Drag and Drop
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();            
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            //A behuzott fajlok neve:
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string file in files)
                    MessageBox.Show(file);            
        }
    }
}