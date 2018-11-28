using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUDP;

namespace Trem
{
    class Trem : Control
    {
        private UDPSocket Udp;
        private Timer Timer;
        
        public Trem(Timer timer, Form pai) : base(pai, "")
        {
            this.Udp = new UDPSocket(this.ReceberMensagem, 6000);
            this.Timer = timer;
        }

        private void ReceberMensagem(byte[] buffer, int size, string ip, int port)
        {
            try
            {
                if (buffer[0] == 0)
                {
                    this.Timer.Enabled = false;
                }
                if (buffer[0] == 1)
                {
                    this.Timer.Enabled = true;
                }
            } catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
