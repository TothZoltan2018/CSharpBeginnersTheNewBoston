using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part141Making_a_DLL
{
    namespace Clients
    {
        public class Client
        {
            internal string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }
    }

    class MyClass
    {
        void MyMethod()
        {
            //Az internal Client class masik napespace-ben van, de ugyanabban a projektben
            Clients.Client c = new Clients.Client(); 
        }
    }
}
