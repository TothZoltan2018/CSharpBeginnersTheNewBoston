using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace FileRelatedParts
{
    //Part176 - Notified When Files Change
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //FileSystemWatcher fsw = new FileSystemWatcher();
            //fsw.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //fsw.NotifyFilter = NotifyFilters.LastWrite;
            //fsw.Filter = "*.txt";

            //Event, ami figyeli a fentieket
            //fsw.Changed += Fsw_Changed;
            //fsw.EnableRaisingEvents = true;

            //tobb kiterjesztes figyelese (a stackoverflow.com-rol)
            //Az egyes filtereknek kulon FileSystemWatcher-t hozunk letre.
            string[] filters = { "*.txt", "*.text" };
            //List<FileSystemWatcher> fswList = new List<FileSystemWatcher>();

            foreach (string filter in filters)
            {
                FileSystemWatcher fsw = new FileSystemWatcher();
                fsw.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //szukithetjuk, hogz milyen esemenytipusokat figyrljen. Ha egyet mar megadunk, akkor
                //csak a felsoroltak lesznek engedelyezve:
                //fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.LastAccess;
                fsw.EnableRaisingEvents = true; //bekapcsoljuk a figyelest
                fsw.Filter = filter; //az ilyen fajl kiterjesztesre figyeljen.
                //minden egyes esemenyt ugyanazok az eventhandler-ek szolgalnak ki.
                fsw.Changed += Fsw_Changed;                
                fsw.Renamed += Fsw_Renamed;                
                //fswList.Add(fsw); //E nelkul is jol mukodik. Minek oket listaban tarolni?                
            }            
        }

        private void Fsw_Renamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show("A textfile has been renamed: " + e.Name);
        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("You have saved a textfile " + e.Name);
        }
    }
}