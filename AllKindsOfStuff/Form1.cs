using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;//

namespace AllKindsOfStuff
{
    //Part115 - MD5 and SHA1
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            string md5Result = BitConverter.ToString(md5.ComputeHash(utf8.GetBytes(textBox1.Text)));

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            string sha1Result = BitConverter.ToString(sha1.ComputeHash(utf8.GetBytes(textBox1.Text)));
            
            MessageBox.Show(md5Result + Environment.NewLine + sha1Result);
        }
    }
}