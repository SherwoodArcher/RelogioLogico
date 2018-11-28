using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelogioLogico
{
    public partial class Form1 : Form
    {
        private int Id;
        private Controlador controller;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            FormId frm = new FormId();
            if (frm.ShowDialog(this) != DialogResult.OK)
            {
                Close();
                return;
            }
            this.Id = frm.Id;
            Text = "Processo " + Id;
            this.controller = new Controlador(this.Id);
            int vizinho1, vizinho2;
            if(this.Id == 1)
            {
                vizinho1 = 2;
                vizinho2 = 3;
            }else if (this.Id == 2)
            {
                vizinho1 = 1;
                vizinho2 = 3;
            } else
            {
                vizinho1 = 1;
                vizinho2 = 2;
            }
            this.controller.SetarVizinho("127.0.0.1", 7000+vizinho1,"127.0.0.1", 7000 + vizinho2);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.controller.SolicitarControle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pausarMovimento_Click(object sender, EventArgs e)
        {
            this.controller.PausarMovimento();
        }

        private void reiniciarMovimento_Click(object sender, EventArgs e)
        {
            this.controller.ReiniciarMovimento();
        }

        private void liberarMovimento_Click(object sender, EventArgs e)
        {
            this.controller.LiberarControle();
        }
    }
}
