using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibUDP;

namespace RelogioLogico
{
    class Controlador
    {
        private int sequenciaLocal;
        public int SequenciaLocal
        {
            get { return sequenciaLocal; }
            set { sequenciaLocal = value; }
        }

        private int sequenciaExterna;
        public int SequenciaExterna
        {
            get { return sequenciaExterna; }
            set { sequenciaExterna = value; }
        }

        private bool secaoCritica;
        public bool SecaoCritica
        {
            get { return secaoCritica; }
            set { secaoCritica = value; }
        }

        private int repliesFaltantes;
        public int RepliesFaltantes
        {
            get { return repliesFaltantes; }
            set { repliesFaltantes = value; }
        }

        private int[] repliesDeferidos;
        public int[] RepliesDeferidos
        {
            get { return repliesDeferidos; }
            set { repliesDeferidos = value; }
        }

        private Vizinho[] vizinhos;
        public Vizinho[] Vizinhos
        {
            get { return vizinhos; }
            set { vizinhos = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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

        private UDPSocket Udp;


        public Controlador(int id)
        {

            this.SequenciaLocal = 0;
            this.SequenciaExterna = 0;
            this.SecaoCritica = false;
            this.RepliesFaltantes = 0;
            this.RepliesDeferidos = new int[3] { 0, 0, 0 };
            this.Id = id;
            this.Ip = "127.0.0.1";
            this.Port = 7000 + id;
            this.Udp = new UDPSocket(this.ReceberMensagem, this.Port);
        }

        public void SetarVizinho(string ip1, int port1, string ip2, int port2)
        {
            this.Vizinhos = new Vizinho[3];
            if (Id == 1)
            {
                this.Vizinhos[1] = new Vizinho(ip1, port1);
                this.Vizinhos[2] = new Vizinho(ip2, port2);
            }
            else if (Id == 2)
            {
                this.Vizinhos[0] = new Vizinho(ip1, port1);
                this.Vizinhos[2] = new Vizinho(ip2, port2);
            }
            else
            {
                this.Vizinhos[0] = new Vizinho(ip1, port1);
                this.Vizinhos[1] = new Vizinho(ip2, port2);
            }
        }

        public void SolicitarControle()
        {
            if (this.SecaoCritica) return;

            this.SecaoCritica = true;

            this.RepliesFaltantes = 2;

            this.SequenciaLocal = this.SequenciaLocal > this.SequenciaExterna ? this.SequenciaLocal : this.SequenciaExterna + 1;

            byte[] bytes = new byte[3] { 0, (byte)this.Id, (byte)this.SequenciaLocal };
            for (int a = 0; a < Vizinhos.Length; a++)
            {
                if (vizinhos[a] == null)
                {
                    continue;
                }
                this.Udp.Send(bytes, this.Vizinhos[a].Ip, this.Vizinhos[a].Port);
            }

        }

        public void ReceberPedidoControle(int id, int sequenciaExterna, string ip, int port)
        {
            if (this.SequenciaExterna < sequenciaExterna)
            {
                this.SequenciaExterna = sequenciaExterna;
            }

            if (this.SecaoCritica)
            {
                if (this.RepliesFaltantes != 0 && this.VerificarRelogios(Id, sequenciaExterna))
                {
                    this.EnviarReply(ip, port);
                }
                else
                {
                    this.RepliesDeferidos[id - 1] = 1;
                }
            }
            else
            {
                this.EnviarReply(ip, port);
            }
        }

        public void EnviarReply(string ip, int port)
        {
            byte[] bytes = new byte[1] { 1 };
            this.Udp.Send(bytes, ip, port);
        }

        public void EnviarRepliesDeferidos()
        {
            byte[] bytes = new byte[1] { 1 };
            for (int a = 0; a < Vizinhos.Length; a++)
            {
                if (this.RepliesDeferidos[a] == 1)
                {
                    this.RepliesDeferidos[a] = 0;
                    this.Udp.Send(bytes, this.Vizinhos[a].Ip, this.Vizinhos[a].Port);
                }
            }
        }

        public void ReceberReply()
        {
            this.RepliesFaltantes--;
        }

        public void ReiniciarMovimento()
        {
            if (this.SecaoCritica && this.RepliesFaltantes == 0)
            {
                byte[] bytes = new byte[1] { 1 };
                this.Udp.Send(bytes, "127.0.0.1", 6000);
            }
        }

        public void PausarMovimento()
        {
            if (this.SecaoCritica && this.RepliesFaltantes == 0)
            {
                byte[] bytes = new byte[1] { 0 };
                this.Udp.Send(bytes, "127.0.0.1", 6000);
            }
        }

        public void LiberarControle()
        {
            if (this.SecaoCritica && this.RepliesFaltantes == 0)
            {
                this.SecaoCritica = false;
                this.EnviarRepliesDeferidos();
            }
        }

        private bool VerificarRelogios(int Id, int SequenciaExterna)
        {
            if (this.SequenciaLocal > SequenciaExterna)
            {
                return true;
            }
            else if (this.SequenciaLocal == SequenciaExterna)
            {
                if (this.Id > Id)
                {
                    return true;
                }
            }
            return false;
        }

        private void ReceberMensagem(byte[] buffer, int size, string ip, int port)
        {
            if (buffer[0] == 0)
            {
                this.ReceberPedidoControle(buffer[1], buffer[2], ip, port);
            }
            if (buffer[0] == 1)
            {
                this.ReceberReply();
            }
        }
    }
}
