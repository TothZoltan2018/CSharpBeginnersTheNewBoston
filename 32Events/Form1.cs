using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _32Events
{
    public partial class Form1 : Form
    {
        Class1 myClass = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Feliratkozunk az esemenyre ezzel a fgv-nyel. Ezt fog lefutni, amikor a esemenyt dobunk.
            myClass.OnPropertyChanged += MyClass_OnPropertyChanged;
            //Itt a valtozas, ami dobja az esemenyt
            myClass.Name = "Zoli";
        }

        private void MyClass_OnPropertyChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"The property has changed. Current value is: {myClass.Name}");
        }
    }
}
