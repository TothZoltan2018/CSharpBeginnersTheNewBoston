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
using System.Xml;

namespace FileRelatedParts
{
    //Part109, 110 - Reading XML,
    //Part111 - Editing XML File
    //Part112, 113 - Writing XML File
    //Part114 - Deleting XML node + Clean a smashed File
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //109
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ofd.FileName);
                MessageBox.Show(xDoc.SelectSingleNode("People/Person/Name").InnerText);
            }
        }

        //110
        private void button2_Click(object sender, EventArgs e)
        {

            XmlDocument xDoc = new XmlDocument();
            {
                xDoc.Load("https://tzoltan.webs.com/TestPeople.xml");
                MessageBox.Show(xDoc.SelectSingleNode("People/Person/Name").InnerText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(ofd.FileName);

                foreach (XmlNode node in xDoc.SelectNodes("People/Person"))
                {
                    label1.Text += node.SelectSingleNode("Name").InnerText + " ";
                }
            }
        }

        //Part111 - Az elso person szerkesztese
        XmlDocument xDoc;
        string path;
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                xDoc = new XmlDocument();
                xDoc.Load(path);
                textBox1.Text = xDoc.SelectSingleNode("People/Person/Name").InnerText;
                numericUpDown1.Value = Convert.ToInt32(xDoc.SelectSingleNode("People/Person/Age").InnerText);
                textBox2.Text = xDoc.SelectSingleNode("People/Person/Email").InnerText;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xDoc.SelectSingleNode("People/Person/Name").InnerText = textBox1.Text;
            xDoc.SelectSingleNode("People/Person/Age").InnerText = numericUpDown1.Value.ToString();
            xDoc.SelectSingleNode("People/Person/Email").InnerText = textBox2.Text;
            xDoc.Save(path);
        }

        //part112 / Writing into new File
        private void button6_Click(object sender, EventArgs e)
        {
            XmlTextWriter xWriter = new XmlTextWriter("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml", Encoding.UTF8 );
            xWriter.Formatting = Formatting.Indented;
            xWriter.WriteStartElement("People");//<People>
            xWriter.WriteStartElement("Person");//<Person>
            xWriter.WriteStartElement("Name");//<Name>
            xWriter.WriteString(textBox3.Text);//textBox3.Text)
            xWriter.WriteEndElement();//</Name>

            xWriter.WriteStartElement("Age");//<Age>
            xWriter.WriteString(numericUpDown2.Value.ToString());//numericUpDown2
            xWriter.WriteEndElement();//</Age>

            xWriter.WriteStartElement("Email");//<Email>
            xWriter.WriteString(textBox4.Text);//textBox4.Text)
            xWriter.WriteEndElement();//</Email>

            xWriter.WriteEndElement();//</Person>
            xWriter.WriteEndElement();//</People>
            xWriter.Close();
        }

        //Part113 Add a new Person Entry to the existing File
        private void button7_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml");
            XmlNode person = xDoc.CreateElement("Person"); //<Person>

            XmlNode name = xDoc.CreateElement("Name"); //<Name>
            name.InnerText = textBox5.Text;
            person.AppendChild(name);//A name-et beteszi a person ala

            XmlNode email = xDoc.CreateElement("Email"); //<Email>
            email.InnerText = textBox6.Text;
            person.AppendChild(email);//A email-t beteszi a person ala

            XmlNode age = xDoc.CreateElement("Age"); //<Name>
            age.InnerText = numericUpDown3.Value.ToString();
            person.AppendChild(age);//Az age-et beteszi a person ala


            xDoc.DocumentElement.AppendChild(person);//a persont beteszi a gyoker ala
            xDoc.Save("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml");

            textBox5.Clear();
            textBox6.Clear();
            numericUpDown3.Value = 0;
        }

        //Part114
        private void button8_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
                if (xNode.SelectSingleNode("Name") != null)
                    if (xNode.SelectSingleNode("Name").InnerText == textBox7.Text)
                        //xNode.RemoveAll(); //Ez a <Person></Person>-t meghagyja
                        xNode.ParentNode.RemoveChild(xNode);

            xDoc.Save("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml");
        }

        //Clean File
        private void button9_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
                if (xNode.SelectSingleNode("Name") == null || xNode.SelectSingleNode("Name").InnerText == string.Empty
                    || xNode.SelectSingleNode("Age") == null || xNode.SelectSingleNode("Age").InnerText == "0"
                    || xNode.SelectSingleNode("Email") == null || xNode.SelectSingleNode("Email").InnerText == string.Empty)
                        xNode.ParentNode.RemoveChild(xNode);
                
            xDoc.Save("C:\\Users\\ZoliRege\\source\\repos\\CSharpBeginnersTheNewBoston\\FileRelatedParts\\xDoc.xml");
        }
    }
}