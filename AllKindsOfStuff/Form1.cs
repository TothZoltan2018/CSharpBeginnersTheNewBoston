using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AllKindsOfStuff
{
    //Part105, 106 107 - WebBrowser Control 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text); //Internet Explorer alapu

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        //Part106
        WebBrowser wb = new WebBrowser();

        private void button6_Click(object sender, EventArgs e)
        {
            wb.Navigate("https://www.pontosido.com/");
            wb.DocumentCompleted += Wb_DocumentCompleted;
        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label1.Text = "A pontos ido: " + wb.Document.GetElementById("clock").InnerText; // Igy is jo: OuterText;
            label2.Text =  "A " + wb.Url.ToString() + " oldalrol.";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            webBrowser2.Document.GetElementById("header-search-input").InnerText = textBox2.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //A weboldalon a kivalasztott elemen vegrehajt egy kattintast
            webBrowser2.Document.GetElementById("header-desktop-search-button").InvokeMember("Click");
        }

        //Jol nez ki, probald ki!
        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    webBrowser2.Document.GetElementById("header-search-input").InnerText = textBox2.Text;
        //}



        

    }
}