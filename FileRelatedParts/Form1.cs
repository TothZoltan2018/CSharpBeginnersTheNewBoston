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
    //Part97 Opening Files from a file browser with this App
    //Right click on a file and click on "Open with
    //De, ha  megragadom a fajlt, es rahuzom az exere, akkor is mukodik:
    //Elindul az exem!!!
    public partial class Form1 : Form
    {
        public Form1(string fileToBeOpen)
        {
            InitializeComponent();
            //Nezd meg a Program.cs-t. Ott veszi at a megnyitando file neveket
            //Jo, nem futtatjuk, csak kiirjuk a nevet
            MessageBox.Show(fileToBeOpen);            
        }
    }
}