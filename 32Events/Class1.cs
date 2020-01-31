using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32Events
{
    class Class1
    {
        public event EventHandler OnPropertyChanged;

        string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                //Megvaltozott a property, dobunk most egy esemenyt
                OnPropertyChanged(this, new EventArgs());
            }
        }
    }
}
