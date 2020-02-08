using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AllKindsOfStuff
{
    //Part69, 70, 71 Threading
    public partial class Form1 : Form
    {        
        Thread t1; //Part69
        Thread t2; //Part70
        Thread t3; //Part71

        public Form1()
        {
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            t1 = new Thread(Freeze);
            t1.Start();
        }

        private void Freeze()
        {
            for (; ; );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t1 != null) t1.Abort();
            if (t2 != null) t2.Abort();
            if (t3 != null) t3.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2 = new Thread(Write);
            t2.Start();
            //Itt varunk, hogy vegezzen a Write() fgv.
            while(t2.IsAlive);
            textBox1.Text = stringForTheTextBox1;
        }

        string stringForTheTextBox1 = string.Empty;        
        void Write()
        {
            for (int i = 0; i < 1000; i++)            
                //System.InvalidOperationException: 'Cross-thread operation not valid: Control 'textBox1'
                //accessed from a thread other than the thread it was created on.'
                //textBox1.Text += "Zoli" + i.ToString() + Environment.NewLine;
                //Nem ferhetunk az uj threadbol a textbox1-hez, ezert tesszuk egy valtozoba.
                stringForTheTextBox1 += "Zoli" + i.ToString() + Environment.NewLine;            
        }

        string stringForTheTextBox2 = string.Empty;
        void WriteWithParams(object myParamArray)
        {//Csak egyetlen object parametert fogadhat, ezert castolni kell az objectet object tombbe
            object[] o = (object[])myParamArray;
            for (int i = 0; i < Convert.ToInt32(o[1]); i++)
                stringForTheTextBox2 += o[0] + i.ToString() + Environment.NewLine;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t3 = new Thread(WriteWithParams);
            //object[] objArray = { "Sugika", 500 };
            t3.Start(new object[] { "Sugika", 500 });
            //Itt varunk, hogy vegezzen a WriteWithParams() fgv.
            while (t3.IsAlive) ;
            textBox2.Text = stringForTheTextBox2;
        }
    }
}