using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    public partial class frmPassRH : Form
    {
        public frmPassRH()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            frmConsultCartao t1 = new frmConsultCartao();
            t1.Show();
            this.Hide();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            frmConsultDinheiro r1 = new frmConsultDinheiro();
            r1.Show();
            this.Hide();
        }
    }
}
