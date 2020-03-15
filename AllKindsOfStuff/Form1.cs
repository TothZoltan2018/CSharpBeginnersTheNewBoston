using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Collections;

namespace AllKindsOfStuff
{
    //Part199 ICloneable
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myName = "Toth Zoli";
            string clone = (string)myName.Clone();
            MessageBox.Show(clone);

            MyCLass mc = new MyCLass();
            mc.Name = "Zoli";

            MyCLass clonedMyClass = (MyCLass)mc.Clone();
            MessageBox.Show($"clonedMyClass.Name property ({clonedMyClass.Name}) is the same as mc.Name ({mc.Name})? {mc.Name == clonedMyClass.Name} ");
            MessageBox.Show($"I've just changed the clonedMyClass.Name propery ({clonedMyClass.Name}) to: {clonedMyClass.Name = "Sugi"}");
            MessageBox.Show($"mc.Name {mc.Name} is also changed to {clonedMyClass.Name}? {mc.Name == clonedMyClass.Name}");
            //This seems to be the same. What is the sense of the Clone() method???????
            MyCLass notClonedMyClass = new MyCLass();
            notClonedMyClass = mc;
            MessageBox.Show($"notClonedMyClass = mc, notClonedMyClass.Name = mc.Name: {notClonedMyClass.Name} = {mc.Name}? {notClonedMyClass.Name == mc.Name}");
        }
    }

    class MyCLass : ICloneable
    {
        public string Name { get; set; }

        public object Clone()
        {
            return this;
        }
    }
}