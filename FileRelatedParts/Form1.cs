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
    //Part42
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
            //olvassuk ki helyes sorrendben az elozo peldaban (41.) kiolvasott Int16, azaz 2 Byte-ot
            //Ez is ugyanugy a masodik byte-ot teszi elore, mint a ReadInt16()
            byte[] buffer = br.ReadBytes(2);
            //1. Megoldas - sajat
            //buffer.Reverse(); 
            //foreach (var aByte in buffer) textBox1.Text += aByte.ToString("x");
            //2. Megoldas
            Array.Reverse(buffer);
            textBox1.Text = BitConverter.ToInt16(buffer, 0).ToString("x");

            br.Dispose();
        }
    }
}