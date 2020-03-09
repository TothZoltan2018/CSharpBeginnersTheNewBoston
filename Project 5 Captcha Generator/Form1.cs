using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;//
using System.IO;//

namespace Project_5_Captcha_Generator
{
    //Part179, 180, 181, 182, 183, 184, 185 - Project 5 Captcha Generator, using the images
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> strings = new List<string>();
        Random rnd = new Random();

        private void button2_Click(object sender, EventArgs e)
        {
            Image[] images = GenerateCapthas(Convert.ToInt32(textBox1.Text));
            int g = 0;
            foreach (Image image in images)
            {
                image.Save(label1.Text + "\\" + strings[g] + ".png");
                g++;
            }
        }

        Image[] GenerateCapthas(int amount)
        {
            Image[] images = new Image[amount];
            
            for (int i = 0; i < amount; i++)
            {
                Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
                Graphics g = Graphics.FromImage(bitmap);//a bitmapra rajzolunk, nem a panel1-re: panel1.CreateGraphics();
                g.Clear(panel1.BackColor);
                //Ha ez itt van, akkor nem generalja le az osszes kepet, es vannak koztuk egyformak is.
                //Ha Sleep(1000), akkor jo. => Ne csinaljunk uj osztalyt mindig, tegyuk ki.
                //Random rnd = new Random();                
                string randomString = DrawRandomString(g, rnd);
                EncodeRandomStringToMd5String(randomString);
                DrawConfusingShapes(g, rnd);

                panel1.BackgroundImage = bitmap;
                images[i] = bitmap;
            }
            
            return images;
        }

        private void DrawConfusingShapes(Graphics g, Random rnd)
        {
            Pen p = new Pen(Color.FromArgb(0xFF, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), 3);
            for (int i = 0; i < 6; i++)
            {
                int j = rnd.Next(0, 2);
                if (j == 0) g.DrawRectangle(p, rnd.Next(0, panel1.Width / 2),
                                            rnd.Next(0, panel1.Height / 2),
                                            rnd.Next(panel1.Width / 2),
                                            rnd.Next(0, panel1.Height / 2));
                else g.DrawEllipse(p, rnd.Next(0, panel1.Width / 2),
                                            rnd.Next(0, panel1.Height / 2),
                                            rnd.Next(panel1.Width / 2),
                                            rnd.Next(0, panel1.Height / 2));
                p.Color = Color.FromArgb(0xFF, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            }
        }

        private string DrawRandomString(Graphics g, Random rnd)
        {
            SolidBrush sb = new SolidBrush(Color.FromArgb(0xFF, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
            char[] chars = "qwertyuiopasdfghjklzxcvbnm0123456789".ToCharArray();
            string randomString = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                randomString += chars[rnd.Next(0, 35)];
            }

            FontFamily ff = new FontFamily("Arial");
            Font f = new System.Drawing.Font(ff, 28);
            g.DrawString(randomString, f, sb, panel1.Width / 10, panel1.Height / 5);
            return randomString;
        }

        private void EncodeRandomStringToMd5String(string randomString)
        {
            string md5String = EncodeStringToMd5String(randomString);
            strings.Add(md5String);
        }

        private static string EncodeStringToMd5String(string randomString)
        {
            byte[] buffer = new byte[randomString.Length]; //kell az md5 enkodolashoz
            int y = 0;
            foreach (char c in randomString)
            {
                buffer[y] = (byte)c;
                y++;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string md5String = BitConverter.ToString(md5.ComputeHash(buffer)).Replace("-", "");// a szokasos .ToString() itt nem jo
            return md5String;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (DialogResult.OK == fd.ShowDialog())
            {
                label1.Text = fd.SelectedPath;
            }
        }

        string md5HashedName = string.Empty;
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                md5HashedName = Path.GetFileNameWithoutExtension(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string encodedUserInput = EncodeStringToMd5String(textBox2.Text);
            if (encodedUserInput != md5HashedName)
            {
                MessageBox.Show("Wrong");
            }
            else MessageBox.Show("Correct!");
        }
    }
}
