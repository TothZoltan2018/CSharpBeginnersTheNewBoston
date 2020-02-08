using System;
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
    //Part60 File Class1, Part61 File Class2, Part62 Path Class
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
                //Part60
                //MessageBox.Show(File.Exists(ofd.FileName).ToString());
                //File.Delete(.....);

                //Part61
                //File.Copy(sourceFileName, targetFileName, overwrite);
                //File.Move(sourceFileName, targetFileName);

                //Part62
                MessageBox.Show(Path.GetDirectoryName(ofd.FileName) + "\n" +
                                Path.GetExtension(ofd.FileName) + "\n" +
                                Path.GetFileName(ofd.FileName));
            }
        }
    }
}