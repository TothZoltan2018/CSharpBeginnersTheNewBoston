using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPaint
{
    //Part 128, 129, 130, 131, 132 - Project 2 Paint Program
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            toolStripComboBox1.Items.Add("Scatter");
            toolStripComboBox1.Items.Add("Continous");
            toolStripComboBox1.SelectedItem = "Continous";           
            numericUpDown1.Value = 4;
            toolStripButton1.ForeColor = Color.Black;            
            canPaint = false;
            sb = new SolidBrush(toolStripButton1.ForeColor);
            shape = Shapes.Pen;
        }

        Graphics g;
        SolidBrush sb;
        bool canPaint;
        Shapes shape;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            sb.Color = toolStripButton1.ForeColor;
            canPaint = true;
            DrawShape(e, shape);      
        }

        private void DrawShape(MouseEventArgs e, Shapes shape)
        {
            switch (shape)
            {
                case Shapes.Square:
                    g.FillRectangle(sb, e.X, e.Y, Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox1.Text));
                    canPaint = false;                    
                    break;
                case Shapes.Rectangle:
                    g.FillRectangle(sb, e.X, e.Y, Convert.ToInt32(toolStripTextBox1.Text), 2 * Convert.ToInt32(toolStripTextBox1.Text));
                    canPaint = false;                    
                    break;
                case Shapes.Circle:
                    g.FillEllipse(sb, e.X, e.Y, Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox1.Text));
                    canPaint = false;
                    break;
                //Pen
                default:
                    canPaint = true;
                    break;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canPaint = false;            
        }

        int? prevX = null;
        int? prevY = null;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canPaint)
            {
                switch (toolStripComboBox1.Text)
                {
                    case "Scatter":
                        sb.Color = toolStripButton1.ForeColor;
                        //SolidBrush sb = new SolidBrush(toolStripButton1.ForeColor);
                        //g.FillEllipse(sb, e.X, e.Y, Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox1.Text));
                        g.FillEllipse(sb, e.X, e.Y, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value));
                        break;
                    case "Continous":
                        //Pen pen = new Pen(toolStripButton1.ForeColor, float.Parse(toolStripTextBox1.Text));
                        Pen pen = new Pen(toolStripButton1.ForeColor, Convert.ToInt32(numericUpDown1.Value));
                        g.DrawLine(pen, new Point(prevX?? e.X, prevY?? e.Y), new Point(e.X, e.Y));
                        prevX = e.X;
                        prevY = e.Y;
                        break;
                    default:
                        break;
                }                
            }
        }        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStripButton1.ForeColor = cd.Color;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStripButton2.ForeColor = panel1.BackColor = cd.Color;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
        }
        
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            shape = Shapes.Square;
            
        }
                
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Shapes.Rectangle;
        }

        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Shapes.Pen;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Shapes.Circle;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] imagePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePath)
            {
                g.DrawImage(Image.FromFile(path), new Point(0, 0));
            }

        }
    }
}
