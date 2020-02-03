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
    //Part43
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
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(path));
            bw.BaseStream.Position = 0;
            //csomo fele tipust irhatunk little endiankent.
            //bw.Write("a");
            //bw.Write(3);
            //bw.Write((short)5);

            //De normal sorrendben igy irjuk:
            //byte[] buffer = BitConverter.GetBytes('e'); //break ele egy 00 byte-ot is. Miert?
            //byte[] buffer = BitConverter.GetBytes(0xEABB1234);
            //byte[] buffer = BitConverter.GetBytes((short)0xAB);
            byte[] buffer = BitConverter.GetBytes((short)171);
            Array.Reverse(buffer);
            bw.Write(buffer);

            bw.Dispose();
        }
    }
}