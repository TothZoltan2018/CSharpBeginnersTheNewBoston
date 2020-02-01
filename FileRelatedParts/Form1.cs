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
 //           ofd.Title = "Open Image";
 //           ofd.Filter = "JPG Image|*jpg|PNG Image|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                textBox1.Text = sr.ReadToEnd();
                sr.Dispose();
            } 
        }
    }
}