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
    //Ezt a formot hozzaadtuk a projekthez.
    public partial class SplashScrreen : Form
    {
        public SplashScrreen()
        {
            InitializeComponent();
        }

        Timer t;
        private void SplashScrreen_Shown(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 2000;
            t.Start();
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            Form1 form = new Form1();
            form.Show();
            this.Hide(); //Elrejti a SplashScrreen-t.            
            //A Program.cs-ben ezt az osztalyt kell beallitani indulokent a Form1 helyett.
        }
    }
}
