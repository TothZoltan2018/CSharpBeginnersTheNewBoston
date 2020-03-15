using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Collections;

namespace AllKindsOfStuff
{
    //Part198 - IDisposable pt 2
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MyClass mc = new MyClass())
            {
                
            }//Itt dispozalja az mc objektumot
        }
    }

    class MyClass : IDisposable
    {
        Image i;
        public MyClass()
        {
            i = Image.FromFile(@"C:\Users\ZoliRege\Documents\7AB6683EEA48580398F2ECD1E3B74964.png");
        }

        //Ezt hivja a using blokk
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //A destruktora nem lesz meghivva
        }

        protected virtual void Dispose(bool b)
        {
            if (b)
            {
                i.Dispose();
            }
        }

        ~MyClass()
        {
            MessageBox.Show("Engem soha nem hivnak meg, a \" GC.SuppressFinalize(this);\" sor miatt!");
        }
    }
}