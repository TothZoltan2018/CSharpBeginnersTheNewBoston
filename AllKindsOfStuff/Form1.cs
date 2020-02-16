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
    //Part102 Property Grid
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Person p = new Person();

        private void button1_Click(object sender, EventArgs e)
        {
            p.Name = "Zoltan";
            p.Age = 11;
            p.Email = "valami@gmail.com";
            //Ez szepen megjeleniti a p osztaly property-eit. (pl. A filed-eket nem.) Ugyanarra az objektumra mutatnak.
            propertyGrid1.SelectedObject = p;
            //A propertyGrid1.SelectedObject-nek a formon is adhatunk erteket.Igy pl a button1-nek tudjuk futas kozben
            //valtoztatni a tulajdonsagait
            Reload();
        }

        private void Reload()
        {
            textBox1.Text = p.Name;
            textBox2.Text = p.Age.ToString();
            textBox3.Text = p.Email;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Reload();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}