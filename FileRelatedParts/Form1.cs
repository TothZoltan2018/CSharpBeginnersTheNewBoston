﻿using System;
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
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                //Peek() - olvas egy karaktert, es nem lep a kovetkezore
                //Read() - olvas egy karaktert, es lep a kovetkezore
                char c =  (char)sr.Peek(); //[0]-t olvassa, utana [0]-n all
                char c2 = (char)sr.Read(); //[0]-t olvassa, utana [1]-n all
                char c3 = (char)sr.Read(); //[1]-t olvassa, utana [2]-n all

                MessageBox.Show(c.ToString() + ", " + c2.ToString() + ", " + c3.ToString());
                sr.Dispose();
            } 
        }
    }
}