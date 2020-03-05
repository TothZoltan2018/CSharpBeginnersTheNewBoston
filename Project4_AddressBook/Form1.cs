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
    //Part 169, 170, 171, 172 - Project 4 Address Book
    //A listView1-en a view-t "list"-re kell allitani
    //A Form property-k kozott ki kell valasztani a ContextMenuStrip1-et
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + "\\AddressBook Project - Zoli"))
                Directory.CreateDirectory(path + "\\AddressBook Project - Zoli");

            if (!File.Exists(path + "\\AddressBook Project - Zoli\\settings.xml"))
                //File.Create(path + "\\AddressBook Project - Zoli\\settings.xml");
                File.Create(path + "\\AddressBook Project - Zoli\\settings.xml");
        }

        //Add Contact
        private void button2_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = textBox1.Text;
            p.Email = textBox2.Text;
            p.StreetAddress = textBox3.Text;
            p.Birthday = dateTimePicker1.Value;
            p.AdditionalNotes = textBox4.Text;
            people.Add(p);
            listView1.Items.Add(p.Name);
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nem vilagos, miert, de eloszor nincs elem a SelectedItems-ben, ezert az if nelkul a kovetkezo
            //sorban kivetlet dobna.
            if (listView1.SelectedItems.Count == 0) return;
            //SelectedItems[0] - csak egy elemet lehet kivalasztani egyszerre.
            //A property-ben be lehet allitani, hogy tobbrt, igy mar ertelmes az indexeles
            textBox1.Text = people[listView1.SelectedItems[0].Index].Name;
            textBox2.Text = people[listView1.SelectedItems[0].Index].Email;
            textBox3.Text = people[listView1.SelectedItems[0].Index].StreetAddress;
            textBox4.Text = people[listView1.SelectedItems[0].Index].AdditionalNotes;
            dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].Birthday;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        void Remove()
        {
            try
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);//A formrol torol
                people.RemoveAt(listView1.SelectedItems[0].Index);//A Listabol is toroljuk
            }
            catch
            { //Nincs egyetlen elem sem kovalasztva}
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
}
