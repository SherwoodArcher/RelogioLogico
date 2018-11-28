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
    public partial class FormId : Form
    {
        public int Id;

        public FormId()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TextBox textBox = textBox1;
            int id = int.Parse(textBox1.Text);
            if (id != 1 && id != 2 && id != 3) return;
            DialogResult = DialogResult.OK;
            this.Id = id;
        }
    }
}
