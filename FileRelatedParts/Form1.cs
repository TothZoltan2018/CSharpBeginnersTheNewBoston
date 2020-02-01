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
         
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                //A fajlban levo elso byte-ot adja vissza tizes szamrendszerben
                //textBox1.Text = sr.BaseStream.ReadByte().ToString();
                //A fajlban levo elso byte-ot adja vissza hexadecimalis szamrendszerben
                //textBox1.Text = sr.BaseStream.ReadByte().ToString("x");

                //A fajlban levo tobb byte-ot olvasunk bufferbe
                //Kezdopozicio megadasa: pl. 4-es index, azaz az 5. elem
                //sr.BaseStream.Position = 4;
                byte[] myBuffer = new byte[6];
                //A bufferbe tegye a 2. helytol kezdve (1-es index) 3 db byte-ot.
                sr.BaseStream.Read(myBuffer, 2, 3);
                foreach (var aByte in myBuffer)
                {
                    textBox1.Text += aByte.ToString("x") + " ";
                }
                
                sr.Dispose();
            } 
        }
    }
}