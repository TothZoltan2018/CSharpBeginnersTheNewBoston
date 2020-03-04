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
    //Part168 - Make a Class for a Foreach Loop
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyCollection mc = new MyCollection("Zoli");
            foreach (string name in mc)
                MessageBox.Show(name);
        }
    }

    class MyCollection : IEnumerable, IEnumerator
    {
        int position = -1;
        List<string> names = new List<string>();
        public MyCollection(string name)
        {
            names.Add(name);
        }

        public object Current
        {
            get { return names[position]; }
        }
        

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < names.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}