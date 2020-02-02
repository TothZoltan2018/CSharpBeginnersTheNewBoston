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
                Read.Enabled = true;
                path = ofd.FileName;
            }
        }

        private void Read_Click(object sender, EventArgs e)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(path));
            br.BaseStream.Position = 3;

            //1. Egyetlen karakter beolvasasa
            //textBox1.Text = br.ReadChar().ToString();
            //2. 4db karaktrt beolvasasa
            //char[] charsFromFile = br.ReadChars(4);
            //foreach (var aChar in charsFromFile) textBox1.Text += aChar;
            //3. Beolvas 2 byte-ot, es 16 bites integerkent ertelmezi little endian sorrendben, azaz jobbrol balra veszi a bajtokat.
            textBox1.Text = br.ReadInt16().ToString("x");
            
            br.Dispose();
        }
    }
}