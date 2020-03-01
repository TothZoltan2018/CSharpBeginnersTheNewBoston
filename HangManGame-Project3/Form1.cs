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
    //Part154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165 - Project 3 Hang Man Game
    public partial class Form1 : Form
    {
        string word = string.Empty;
        List<Label> labels = new List<Label>();
        int amountOfMissedLetters = 0;

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
            for (int i = 0; i < chars.Length; i++)
            {
                labels.Add(new Label());                
                labels[i].Location = new Point((i * between) + 10, 80);
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
            label1.Text = "Word Length: " + (chars.Length).ToString();
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
            if (textBox1.Text != string.Empty)
            {
                char letter = textBox1.Text.ToLower().ToCharArray()[0];
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
                    foreach (Label l in labels)                    
                        if (l.Text == "_") return; //Ha meg vannak ismeretlen betuk
                    MessageBox.Show("You have won!", "Congrats");
                    ResetGame();
                }
                else
                {
                    MessageBox.Show("The letter that you guessed isn't in the word!", "Sorry");
                    label2.Text += letter + ", ";
                    DrawBodyPart((BodyParts)amountOfMissedLetters);
                    amountOfMissedLetters++;
                    if (amountOfMissedLetters == 9) //8 reszbol all az ember
                    {
                        MessageBox.Show("Sorry, but you lost! The word was: " + word);
                        ResetGame();
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Please submit a letter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void ResetGame()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            //GetRandomWord();
            MakeLabels();
            DrawHangPost();            
            label2.Text = "Missed: ";
            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == word)
            {
                MessageBox.Show("You have won!", "Congrats");
                ResetGame();
            }
            else
            {
                MessageBox.Show("The word you guessed is wrong!", "Sorry");
                DrawBodyPart((BodyParts)amountOfMissedLetters);
                amountOfMissedLetters++;

                if (amountOfMissedLetters == 9) //8 reszbol all az ember
                {
                    MessageBox.Show("Sorry, but you lost! The word was: " + word);
                    ResetGame();
                }
            }
        }
    }
}
