using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysAndStrings
{
    //Part49, 50, 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Part49 Substrings
            //string name = "Wolfgang Amadeus Mozart";
            //string FirstName = name.Substring(0, 8);                        
            //MessageBox.Show(FirstName);

            //Part50 IndexOf and Trim
            //string name = "      Wolfgang Amadeus Mozart     ";
            //string trimmedName = name.Trim(); //name.TrimStart() TrimeEnd
            //string FirstName = trimmedName.Substring(0, trimmedName.IndexOf(' '));            
            //string MiddleAndLastName = trimmedName.Substring(trimmedName.IndexOf(' ') + 1);
            //string MiddleName = MiddleAndLastName.Substring(0, MiddleAndLastName.IndexOf(' '));
            //string LastName = MiddleAndLastName.Substring(MiddleAndLastName.IndexOf(' ') + 1);
            //MessageBox.Show(FirstName + "\n" + MiddleName + "\n" + LastName);

            //Part51 Remove and Replace
            //string sentence = "Hello, my name is Zoli";
            //string removedHello = sentence.Remove(0, 7);
            //string removedZoli = sentence.Remove(17);
            //string replacedHello = sentence.Replace("Hello", "Hi");
            //MessageBox.Show(removedHello + "\n" + removedZoli + "\n" + replacedHello); //karkterekkel is tudja ('', '')

            //Part52 Split and ToCharArray            
            string names = "Zolika,Sugi, Rege ,Zoli;Aranka; Ica ;Dedi";
            char[] separatorChars = { ',', ' ', ';' };
            string[] nameArray = names.Split(separatorChars, StringSplitOptions.RemoveEmptyEntries);
            //string[] separatorStrings = { ",", ", ", " ,", ";", "; ", " ;" };
            //string[] nameArray = names.Split(separatorStrings, StringSplitOptions.RemoveEmptyEntries);//Ez sokoldalubb
            //foreach (string name in nameArray) MessageBox.Show(name);

            string _letters = "abcdefghijkl";
            char[] letters = _letters.ToCharArray();
        }
    }
}
