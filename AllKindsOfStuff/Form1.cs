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
using System.Net;//

namespace AllKindsOfStuff
{
    //Part72 Webclient DownloadString, Part73 Download files
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Part72
            //WebClient wc = new WebClient();
            //textBox1.Text = wc.DownloadString("https://pastebin.com/index/cgKiziiQ");   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Part73
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WebClient wc = new WebClient();
                wc.DownloadFileAsync(new Uri("https://drive.google.com/open?id=1hwJ3nR_mFTy2ditwBFEMtL-IDUhaHNYs"), sfd.FileName);
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;//ugyanez: new AsyncCompletedEventHandler(Wc_DownloadFileCompleted);
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label1.Text = "Progress: " + e.ProgressPercentage.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File is downloaded.");
        }
    }
}