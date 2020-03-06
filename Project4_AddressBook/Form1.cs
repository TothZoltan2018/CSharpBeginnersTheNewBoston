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
using System.Xml;//

namespace Project4_AddressBook
{
    //Part 169, 170, 171, 172, 173, 174, 175 - Project 4 Address Book
    //A listView1-en a view-t "list"-re kell allitani
    //A Form property-k kozott ki kell valasztani a ContextMenuStrip1-et
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        string path = string.Empty;
        XmlTextWriter xW;
        XmlDocument xDoc = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + "\\AddressBook Project - Zoli"))
                Directory.CreateDirectory(path + "\\AddressBook Project - Zoli");
            //C:\Users\ZoliRege\AppData\Roaming\AddressBook Project - Zoli

            if (!File.Exists(path + "\\AddressBook Project - Zoli\\settings.xml"))
            {
                //File.Create(path + "\\AddressBook Project - Zoli\\settings.xml"); //Ez csak egy sima, ures fajl
                xW = new XmlTextWriter(path + "\\AddressBook Project - Zoli\\settings.xml", Encoding.UTF8);
                xW.WriteStartElement("People");
                xW.WriteEndElement();
                xW.Close();
            }

            //XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path + "\\AddressBook Project - Zoli\\settings.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
            {
                Person p = new Person();
                p.Name = xNode.SelectSingleNode("Name").InnerText;
                p.Email = xNode.SelectSingleNode("Email").InnerText;
                p.StreetAddress = xNode.SelectSingleNode("Address").InnerText;
                p.AdditionalNotes = xNode.SelectSingleNode("Notes").InnerText;
                //p.Birthday = Convert.ToDateTime(xNode.SelectSingleNode("Birthday").InnerText);
                p.Birthday = DateTime.Parse(xNode.SelectSingleNode("Birthday").InnerText);

                people.Add(p);
                listView1.Items.Add(p.Name);
            }
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
            //sorban kivetelt dobna.
            if (listView1.SelectedItems.Count == 0) return;
            //SelectedItems[0] - csak egy elemet lehet kivalasztani egyszerre.
            //A property-ben be lehet allitani, hogy tobb, igy mar ertelmes az indexeles
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
                people.RemoveAt(listView1.SelectedItems[0].Index);//A Listabol toroljuk
                listView1.Items.Remove(listView1.SelectedItems[0]);//A formrol is toroljuk                
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

        //Save Changes
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || people.Count == 0) return;
            people[listView1.SelectedItems[0].Index].Name = textBox1.Text;
            people[listView1.SelectedItems[0].Index].Email = textBox2.Text;
            people[listView1.SelectedItems[0].Index].StreetAddress = textBox3.Text;
            people[listView1.SelectedItems[0].Index].AdditionalNotes = textBox4.Text;
            people[listView1.SelectedItems[0].Index].Birthday = dateTimePicker1.Value;
            listView1.SelectedItems[0].Text = textBox1.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fajlba irjuk a listankat
            //xDoc = new XmlDocument();
            //xDoc.Load(path + "\\AddressBook Project - Zoli\\settings.xml");

            //a duplikatumok elkerulese erdekeben az elemek kiirasa elott toroljuk a fajl tartalmat.
            XmlNode xNode = xDoc.SelectSingleNode("People");
            xNode.RemoveAll();

            foreach (Person person in people)
            {
                XmlNode xPerson = xDoc.CreateElement("Person");
                XmlNode xName = xDoc.CreateElement("Name");
                XmlNode xEmail = xDoc.CreateElement("Email");
                XmlNode xAddress = xDoc.CreateElement("Address");
                XmlNode xNotes = xDoc.CreateElement("Notes");
                XmlNode xBirthday = xDoc.CreateElement("Birthday");

                xName.InnerText = person.Name;
                xEmail.InnerText = person.Email;
                xAddress.InnerText = person.StreetAddress;
                xNotes.InnerText = person.AdditionalNotes;
                //xBirthday.InnerText = person.Birthday.ToFileTime().ToString();
                xBirthday.InnerText = person.Birthday.ToString();

                xPerson.AppendChild(xName);
                xPerson.AppendChild(xEmail);
                xPerson.AppendChild(xAddress);
                xPerson.AppendChild(xNotes);
                xPerson.AppendChild(xBirthday);

                xDoc.DocumentElement.AppendChild(xPerson);
            }
            xDoc.Save(path + "\\AddressBook Project - Zoli\\settings.xml");
        }
    }
}
