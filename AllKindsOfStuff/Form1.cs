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
using System.Collections;//
namespace AllKindsOfStuff
{
    //Part167 - IEnumerable and Yield Return
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int i in GetNumbers(0, 10))
            {
                if (i >= 6) break;
                textBox1.Text += i.ToString() + ", ";                
            }

            foreach (int i in GetNumbers2())
            {
                if (i >= 6) break;                
                textBox2.Text += i.ToString() + ", ";
            }

            foreach (var item in GetNumbers2())
            {
                textBox3.Text += item.ToString() + ", ";
            }            
        }

        //A fgv nem fog min-tol max-1-ig mindig lefutni, hanem a hivaskor egyet iteral.
        //Teljesitmenytakarekos, csak annyit szamol, amennyit a hivas helyen felhasznalunk.
        IEnumerable GetNumbers(int min, int max)
        {
            for (; min <= max; min+=2)
            {
                yield return min;
            }
        }
        //Ugyanaz, mint fent. Minden hivaskor visszaadja a kovetkezo integert.
        IEnumerable GetNumbers2()
        {
            yield return 0;
            yield return 2;
            yield return 4;
            yield return 6;
            yield return 8;
            yield return 10;
        }

    }
}