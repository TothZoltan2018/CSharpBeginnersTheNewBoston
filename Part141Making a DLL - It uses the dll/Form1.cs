using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Part141Making_a_DLL.Clients;//Ebben van a Client osztalyunk

namespace Part141Making_a_DLL___It_uses_the_dll
{
    //Part 142 - Internal Access Modifier
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ha a Client internal, akkor ebben a projektben nem latszik:
            //Ha a CLient public, e egy adattagja internal, akkor az az adattag nem latszik
            Client c = new Client();
            //c.Name = "Z";
        }
    }
}
