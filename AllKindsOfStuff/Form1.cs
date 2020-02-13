using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AllKindsOfStuff
{
    //Part85 Playing Sounds
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    SoundPlayer s = new SoundPlayer(ofd.FileName);
            //    s.Play();
            //    //s.PlayLooping();                
            //}

            SystemSounds.Asterisk.Play();
        }
    }
}