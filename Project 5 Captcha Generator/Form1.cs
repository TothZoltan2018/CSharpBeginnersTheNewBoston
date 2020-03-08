﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_5_Captcha_Generator
{
    //Part179, 180, 181 - Project 5 Captcha Generator
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateCapthas(0);
        }

        Image[] GenerateCapthas(int amount)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            Random rnd = new Random();

            #region Szoveg rajzolas
            SolidBrush sb = new SolidBrush(Color.FromArgb(0xFF, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
            char[] chars = "qwertyuiopasdfghjklzxcvbnm0123456789".ToCharArray();
            string randomString = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                randomString += chars[rnd.Next(0, 35)];
            }
            FontFamily ff = new FontFamily("Arial");
            Font f = new System.Drawing.Font(ff, 28);
            g.DrawString(randomString, f, sb, panel1.Size.Width/10, panel1.Size.Height/5);
            #endregion

            Pen p = new Pen(Color.FromArgb(0xFF, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), 3);
            //Todo: 2 azonos ciklus van. Ki kellene fgv-be tenni a betuk es a sikidomok rajzolasat
            for (int i = 0; i < 6; i++)
            {
                int j = rnd.Next(0, 2);
                if (j == 0) g.DrawRectangle(p, rnd.Next(0, panel1.Size.Width/2),
                                            rnd.Next(0, panel1.Size.Height/2),
                                            rnd.Next(panel1.Size.Width/2),
                                            rnd.Next(0, panel1.Size.Height/2));
                else g.DrawEllipse(p, rnd.Next(0, panel1.Size.Width / 2),
                                            rnd.Next(0, panel1.Size.Height / 2),
                                            rnd.Next(panel1.Size.Width / 2),
                                            rnd.Next(0, panel1.Size.Height / 2));
                p.Color = Color.FromArgb(0xFF, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            }
                       
            return null;
        }
    }
}
