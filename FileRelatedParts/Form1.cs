using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Part 34
/// </summary>
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
            ofd.Title = "Open Image";
            ofd.Filter = "JPG Image|*jpg|PNG Image|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Successfully open: {ofd.FileName}.");
            } 
        }
    }
}