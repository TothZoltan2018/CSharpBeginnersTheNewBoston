using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AllKindsOfStuff
{
    //
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("People"); //ez a fa egyik gyokere --> treeView1.Nodes[0]
            treeView1.Nodes.Add("Animals"); //ez a fa masik gyokere --> treeView1.Nodes[1]
            treeView1.Nodes[0].Nodes.Add("Zolika");
            treeView1.Nodes[0].Nodes.Add("Sugika");
            treeView1.Nodes[0].Nodes.Add("Rege");
            treeView1.Nodes[1].Nodes.Add("Dog");
            treeView1.Nodes[1].Nodes.Add("Cat");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Foxhund");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Wolf-Dog");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }
                
        void RemoveCheckedNodes(TreeNodeCollection tnc)
        {
            List<TreeNode> tnListToBeRemoved = new List<TreeNode>();
            foreach (TreeNode node in tnc)
                if (node.Checked) tnListToBeRemoved.Add(node);
                else if (node.Nodes.Count != 0) RemoveCheckedNodes(node.Nodes); //vannak alatta Node-ok, azokra rekurzio
            foreach (TreeNode node in tnListToBeRemoved)
            {
                node.Remove();
                //treeView1.Nodes.Remove(node); //ugyanaz, mint fentebb
            }
         }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveCheckedNodes(treeView1.Nodes);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MyRemoveCheckedNodes(treeView1.Nodes); //Ez kivetelt dob!
        }

        private void MyRemoveCheckedNodes(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Checked) node.Remove(); //Ez kivetelt dob!
                else if (node.Nodes.Count != 0) MyRemoveCheckedNodes(node.Nodes);                
            } 
        }

        //Part101
        //1. Rahuzok egz ImageList-et a form-ra
        private void button6_Click(object sender, EventArgs e)
        {
            //2.
            TreeNode tnPers = new TreeNode();
            tnPers.Text = "Pers.";
            tnPers.SelectedImageIndex = tnPers.ImageIndex = 1;            
            treeView1.Nodes.Add(tnPers);
            //3. A UI-on A treeView1 propertyknel meg kell adni az imageList-unket/
            TreeNode tnSugika = new TreeNode();
            tnSugika.Text = "Sugika";
            tnSugika.SelectedImageIndex = tnSugika.ImageIndex = 2;
            treeView1.Nodes[0].Nodes.Add(tnSugika);
            TreeNode tnZolika = new TreeNode();
            tnZolika.Text = "Sugika";
            tnZolika.SelectedImageIndex = tnZolika.ImageIndex = 3;
            treeView1.Nodes[0].Nodes.Add(tnZolika);

            //TreeNode tnAnimals = new TreeNode();
            //tnAnimals.Text = "Animals";
            //treeView1.Nodes.Add(tnAnimals);
            treeView1.Nodes.Add("Animals");
            treeView1.Nodes[1].Nodes.Add("Dogs");          
            TreeNode tnWolfDog = new TreeNode();
            tnWolfDog.Text = "Wolf-Dog";
            tnWolfDog.ImageIndex = 4;
            tnWolfDog.SelectedImageIndex = 4;
            treeView1.Nodes[1].Nodes[0].Nodes.Add(tnWolfDog);
        }
    }
}