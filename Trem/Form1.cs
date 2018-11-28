using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trem
{
    public partial class Form1 : Form
    {
        private Trem trem;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            trem = new Trem(timer, this);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Left += 5;
            if (label1.Left >= ClientSize.Width)
            {
                label1.Left = -label1.Width;
            }
        }
    }
}
