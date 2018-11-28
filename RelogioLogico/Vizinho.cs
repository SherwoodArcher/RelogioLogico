using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelogioLogico
{
    class Vizinho
    {
        private string ip;
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private int port;
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public Vizinho(string ip, int port)
        {
            this.Ip = ip;
            this.Port = port;
        }
    }
}
