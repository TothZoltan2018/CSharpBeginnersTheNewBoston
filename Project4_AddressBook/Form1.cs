using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_AddressBook
{
    //Part 169, 170 - Project 4 Address Book
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if(!Directory.Exists(path + "\\AddressBook Project - Zoli"))
                Directory.CreateDirectory(path + "\\AddressBook Project - Zoli");

            if(!File.Exists(path + "\\AddressBook Project - Zoli\\settings.xml"))
                //File.Create(path + "\\AddressBook Project - Zoli\\settings.xml");
                File.Create(path + "\\AddressBook Project - Zoli\\settings.xml");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime Birthday { get; set; }
    }
}
