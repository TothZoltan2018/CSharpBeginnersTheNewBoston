using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorOverloading
{
    //Part152 - Making Conversion Operators
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ------- VAGY EZ --------
            //Item i = (Item)3; //Explicit            
            // ------- VAGY EZ --------
            Item i = 3; //Implicit, nem kell a cast operator
            MessageBox.Show(i.Price.ToString());        }
    }

    class Item
    {
        public int Price { get; set; }

        //public static explicit operator Item(int itemPrice)
        //{
        //    Item i = new Item();
        //    i.Price = itemPrice;
        //    return i;
        //}

        public static implicit operator Item(int itemPrice)
        {
            Item i = new Item();
            i.Price = itemPrice;
            return i;
        }
    }
}
