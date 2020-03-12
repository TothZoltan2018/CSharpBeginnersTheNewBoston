using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZolisIO;

namespace Project_6_Reading_and_Writing_Classes
{
    //Part186 - Project 6 Reading and Writing Class
    //A BitReader/Writer osztaly Little Endian modon (forditva) kezeli a szamokat.
    //Ezert irjunk egy oszalyt, aminek megadhatjuk, hogy Little v. Big Endian kezelje.
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
                Reader r = new Reader(ofd.FileName);
                MessageBox.Show(r.ReadInt32().ToString("X"));
            }
        }
    }
}
