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
    //Part44
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            sfd.FileName = "TestText";
            sfd.Title = "Save Zoli's testfile";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write("Example text file"); //Miert tesz a fajl elejere egy 0x11 (device control 1) karaktert?

                bw.Dispose();
            }
        }
    }
}