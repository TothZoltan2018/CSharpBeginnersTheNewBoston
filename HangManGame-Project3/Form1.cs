using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //A veletlen szavak listajanak letoltesehez

namespace HangManGame_Project3
{
    //Part154, 155, 156, 157, 158, 159, 160, 161, 162 - Project 3 Hang Man Game
    public partial class Form1 : Form
    {
        string word = string.Empty;
        List<Label> labels = new List<Label>();

        public Form1()
        {
            InitializeComponent();
            MakeLabels();
        }

        void DrawHangPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(130, 218), new Point(130, 5));
            g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            g.DrawLine(p, new Point(60, 0), new Point(60, 50));

            DrawBodyPart(BodyParts.Head);
            DrawBodyPart(BodyParts.Left_Eye);
            DrawBodyPart(BodyParts.Right_Eye);
            DrawBodyPart(BodyParts.Mouth);
            DrawBodyPart(BodyParts.Body);
            DrawBodyPart(BodyParts.Left_Arm);
            DrawBodyPart(BodyParts.Right_Arm);
            DrawBodyPart(BodyParts.Left_Leg);
            DrawBodyPart(BodyParts.Right_Leg);

        }

        void DrawBodyPart(BodyParts bp)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            SolidBrush s = new SolidBrush(Color.Black);
            switch (bp)
            {
                case BodyParts.Head:
                    g.DrawEllipse(p, 40, 50, 40, 40);
                    break;
                case BodyParts.Left_Eye:                    
                    g.FillEllipse(s, 50, 60, 5, 5);
                    break;
                case BodyParts.Right_Eye:                    
                    g.FillEllipse(s, 63, 60, 5, 5);
                    break;
                case BodyParts.Mouth:
                    g.DrawArc(p, 50, 75, 20, 20, 225, 90);
                    break;
                case BodyParts.Right_Arm:
                    g.DrawLine(p, new Point(60, 100), new Point(90, 85));
                    break;
                case BodyParts.Left_Arm:
                    g.DrawLine(p, new Point(60, 100), new Point(30,85));
                    break;
                case BodyParts.Body:
                    g.DrawLine(p, new Point(60, 90), new Point(60, 170));
                    break;
                case BodyParts.Right_Leg:
                    g.DrawLine(p, new Point(60, 170), new Point(90, 190));
                    break;
                case BodyParts.Left_Leg:
                    g.DrawLine(p, new Point(60, 170), new Point(30, 190));
                    break;
                default:
                    break;
            }
        }

        void MakeLabels()
        {
            word = GetRandomWord();
            char[] chars = word.ToCharArray(); //A vegen van meg egy '\n' is.
            int between = groupBox2.Width / chars.Length - 1;
            for (int i = 0; i < chars.Length - 1; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * between) + 10, 80);
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
            label1.Text = "Word Length: " + (chars.Length - 1).ToString();
        }

        string GetRandomWord()
        {
            WebClient wc = new WebClient();
            string wordList = wc.DownloadString("https://www.mit.edu/~ecprice/wordlist.10000");

            string[] wordArray = wordList.Split(Environment.NewLine.ToCharArray());
            Random rnd = new Random();
            int rndIndex = rnd.Next(wordArray.Length - 1);

            return wordArray[rndIndex];            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            DrawHangPost();
        }

        enum BodyParts
        {
            Head, Left_Eye, Right_Eye, Mouth, Right_Arm, Left_Arm, Body, Right_Leg, Left_Leg        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char letter = textBox1.Text.ToCharArray()[0];
            if (!char.IsLetter(letter))
            {
                MessageBox.Show("You can only submit letters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (word.Contains(letter)) //Van ilyen betu a szoban?
            {
                char[] letters = word.ToCharArray(); //A szoban levo osszes betu, karaktertombben
                //Menjunk vegig a szo karakterein, nezzuk meg, melyik helyen allnak ilyen betuk
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letter)
                        labels[i].Text = letters[i].ToString();
                }
            }
        }
    }
}
