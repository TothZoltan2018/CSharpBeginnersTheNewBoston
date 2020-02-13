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
    //Part90, 91, 92, 93, 94 ListView Control
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(textBox1.Text); //1. oszlopba kerul
            lvi.SubItems.Add(textBox3.Text); //2. oszlopba kerul
            lvi.SubItems.Add(textBox2.Text); //3. oszlopba kerul
            listView1.Items.Add(lvi);
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;

            //A listView1-t kijelolve odahuztunk egy contextMenuStrip-et, beleirtunk, es a listView1 propertijeben megadtuk.
            //Futas kozben jobb kattra elojon, amit beirtunk
        }

        private void getNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)                
                    MessageBox.Show(listView1.SelectedItems[0].SubItems[0].Text);                
            }
        }

        private void removeSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)            
                foreach (ListViewItem lvi in listView1.SelectedItems)
                    lvi.Remove();            
        }

        private void removeAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        //checkBoxes property-t true-ra allitva a listBox1 sorai elott checkbox van.
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.Items)
                if (lvi.Checked) lvi.Remove();
        }        
    }
}