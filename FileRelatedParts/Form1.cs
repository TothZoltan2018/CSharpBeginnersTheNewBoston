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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path;
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Write.Enabled = true;
                path = ofd.FileName;
            }
        }

        private void Write_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(File.OpenWrite(path));
            sw.BaseStream.Position = 0x02; //A 2. indexu byte-ot fogjuk atirni
           //sw.BaseStream.WriteByte(0xFF);//FF-re

            byte[] mybuffer = { 0x60, 0x61, 0x62, 0x63, 0x64 };
            //Tobb byte atirasa a megadott bufferbol, a buffer megadott elemetol kezdve adott darab byte-ot
            sw.BaseStream.Write(mybuffer, 1, 3);            

            sw.Dispose();
        }
    }
}