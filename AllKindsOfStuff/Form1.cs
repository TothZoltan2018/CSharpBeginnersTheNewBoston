using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //A Process osztalyhoz

namespace AllKindsOfStuff
{
    //Part63 Process Class1, Part64 Process Class2
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////Part63
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{                
            //    //Process.Start(ofd.FileName);
            //    //System32 alatti programoknal nem kell a teljes eleresi ut, csak az exe neve.
            //    //Process.Start("Notepad.exe");
            //    //MessageBox.Show(Process.GetCurrentProcess().ProcessName);
            //    //Process.GetCurrentProcess().Kill();
            //}

            //Part64                            
            foreach (var process in Process.GetProcesses())
            {
                textBox1.Text += process.ProcessName + " - responding: " +
                                 process.Responding.ToString() + Environment.NewLine; //erdekes, a "\n" nem mukodott
                
            }
            //Process.GetProcessesByName(Chrome); //az osszes ilyen nevu process-t tombe teszi.
        }
    }
}