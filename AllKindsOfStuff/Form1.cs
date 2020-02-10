using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AllKindsOfStuff
{
    //Part77 DateTime struct, Part78 DateTimePicker
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Part77
            DateTime dt1 = new DateTime(1997, 8, 27, 18, 44, 55);            
            DateTime dt2 = DateTime.Today;
            DateTime dt3 = DateTime.Now;
            string dt4 = DateTime.IsLeapYear(1977).ToString();
            string dt5 = DateTime.IsLeapYear(Convert.ToInt32(DateTime.Today.Year)).ToString();
            string dt6 = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString();
            string dt7 = DateTime.Now.ToFileTime().ToString("x");
            string dt8 = DateTime.FromFileTime(DateTime.Now.ToFileTime()).ToString();

            MessageBox.Show(dt1.ToString() + "\n" + dt2.ToString() + "\n" + dt3.ToString() + "\n" + dt4 + "\n" + dt5 + "\n" + dt6 + "\n" + dt7 + "\n" + dt8);
        }

        //Part78
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            MessageBox.Show(dt.ToString());
        }
    }
}