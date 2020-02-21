using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;//
using System.Threading;

namespace Drawing
{
    //Part 124, 125 - LinearGradientBrush
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(60, 60), new Point(120, 120), Color.Red, Color.Blue);
            Graphics g = panel1.CreateGraphics();            
            for (int i = 0; i < 180; i += 1)
            {
                //Thread.Sleep(10);
                g.RotateTransform(i);
                g.FillRectangle(lgb, 60, 60, 120, 120);
                g.FillEllipse(lgb, 20, 20, 50, 50);                
            }
            //125
            g = panel1.CreateGraphics(); //Ha ez nincs, akkor nem rajzol ujabbakat.

            ColorBlend cb = new ColorBlend
            {
                Colors = new Color[] { Color.Black, Color.Blue, Color.Orange, Color.Wheat },
                Positions = new float[] { 0, 0.5F, 0.75F, 1F } //0...1
            };

            lgb = new LinearGradientBrush(new Point(120, 120), new Point(120, 470), Color.Black, Color.Red)
            {
                InterpolationColors = cb
            };

            g.FillEllipse(lgb, 120, 120, 350, 350);
        }
    }
}
