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
    //Part116, 117 - TripleDES Encryption/Decryption
    public partial class Form1 : Form
    {
        TripleDESCryptoServiceProvider tDes;
        UTF8Encoding utf8;
        byte[] encrypted;

        public Form1()
        {
            InitializeComponent();            
        }

        private void SetupCryption(TextBox tbox)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            utf8 = new UTF8Encoding();

            tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = md5.ComputeHash(utf8.GetBytes(tbox.Text));
            //A decrypteleshez kell ez a ket sor:
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetupCryption(textBox1);
            ICryptoTransform trans = tDes.CreateEncryptor();
            //ez vegzi el tenylegesen a titkositast a textBox2.Text szovegen.
            encrypted = trans.TransformFinalBlock(utf8.GetBytes(textBox2.Text), 0, utf8.GetBytes(textBox2.Text).Length);
            textBox3.Text = BitConverter.ToString(encrypted);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetupCryption(textBox4);
            ICryptoTransform trans = tDes.CreateDecryptor();
            try
            {
                textBox5.Text = utf8.GetString(trans.TransformFinalBlock(encrypted, 0, encrypted.Length));
            }
            catch (Exception exce)
            {
                MessageBox.Show("Ooooo!" + exce.Message);
            }            
        }  
    }
}