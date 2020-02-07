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
    //Part56 FolderBrowsingDialog, Part57 Directory class1, Part58 Directory class2, Part59 Directory class3
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Part56, 57
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "A zoxigen kihasznalasara a vizbul veszi ki a zoxigent, teccikerteni?";
            fbd.RootFolder = Environment.SpecialFolder.UserProfile;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Text = fbd.SelectedPath;
                string[] files = Directory.GetFiles(fbd.SelectedPath);//Directory.GetDirectories, Directory.GetLogicalDrives
                foreach (var file in files)
                {
                    textBox1.Text += file + "\n";
                    label1.Text += file + "\n";
                }

                //Part58
                maskedTextBox1.Text = Directory.GetCreationTime(fbd.SelectedPath).ToString(); //sok egyeb idoinfo is van meg.
                MessageBox.Show(Directory.GetParent(fbd.SelectedPath).ToString());

                //Part59
                Directory.CreateDirectory(fbd.SelectedPath + "\\ZoliTest\\Source");
                //Directory.Exists(fbd.SelectedPath + "\\ZoliTest\\Destination");
                try
                {
                    Directory.Move(fbd.SelectedPath + "\\ZoliTest\\Source", fbd.SelectedPath + "\\ZoliTest\\Destination");
                }
                catch (Exception eDir)
                {
                    MessageBox.Show(eDir.Message.ToString());
                }
                //Directory.Delete() - ures vagy mindent, rekurzivan
            }
        }
    }
}