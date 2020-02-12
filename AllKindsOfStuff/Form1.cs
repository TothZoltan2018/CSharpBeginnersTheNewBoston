using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AllKindsOfStuff
{
    //Part80 ClipBoard class
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Autóvásárlás\Vértes Hyundai drágább\HYUNDAI I30 CW 1.4i Life_files\13817980_1.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Jeloljunk ki barhol egy szoveget, majd ctrl+c, utana katt a gombra...
            textBox2.Text = Clipboard.GetText();

            //2.
            //Clipboard.GetData(DataFormats.Rtf);

            //3.
            Clipboard.SetText("Zoli");

            //4.
            Clipboard.SetImage(pictureBox1.Image);
            pictureBox2.Image = Clipboard.GetImage();

            Clipboard.Clear();
        }

    }
}