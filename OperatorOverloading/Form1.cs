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
    //Part148, 149, 150, 151 - Overloading Operators
    public partial class Form1 : Form
    {
        static Item item1 = new Item();
        static Item item2 = new Item();
        static Item item3 = new Item();


        public Form1()
        {
            InitializeComponent();
            item1.Price = 3;
            item2.Price = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Part148();
            Part149();
            Part150();
            Part151();
        }

        private static void Part151()
        {
            item3 = item3++;
            //MessageBox.Show(Convert.ToString(item3.Price));
            MessageBox.Show("item3++ = " + item3.Price.ToString());
        }

        private static void Part150()
        {
            if (item1 < item2) MessageBox.Show("The first item is smaller than the second.");
            if (item1 > item2) MessageBox.Show("The first item is greater than the second.");

        }

        private static void Part149()
        {
            if (item1 == item2) MessageBox.Show("These items are the same.");
            if (item1 != item2) MessageBox.Show("These items are NOT the same.");
        }

        private static void Part148()
        {            
            item3 = item1 + item2;
            //MessageBox.Show(Convert.ToString(item3.Price));
            MessageBox.Show(item3.Price.ToString());
        }
    }

    public class Item
    {
        public int Price { get; set; }

        //Operator: mindig public static        
        public static Item operator +(Item i1, Item i2)
        {
            Item i3 = new Item();
            i3.Price = i1.Price + i2.Price;
            return i3;
        }

        public static bool operator ==(Item i1, Item i2)
        {
            return (i1.Price == i2.Price) ? true : false;
        }

        //Ha '==' overload-olt, akkor meg kell csinalni '!=-'t is
        public static bool operator !=(Item i1, Item i2)
        {
            return (i1.Price != i2.Price) ? true : false;
        }

        public static bool operator <(Item i1, Item i2)
        {
            return (i1.Price < i2.Price) ? true : false;
        }
        //Ha '<' overload-olt, akkor meg kell csinalni '>'t is
        public static bool operator >(Item i1, Item i2)
        {
            return (i1.Price > i2.Price) ? true : false;
        }

        //lehetne <= es >= is

        public static Item operator ++(Item item)
        {
            //A tutorial megoldasa:
            //Item i = new Item();
            //i.Price = item.Price++;
            //return i;
            item.Price++;
            return item;
        }

        //A -- is lehetne.        
    }
}
