using Inicio.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
            ArredondaCantosdoForm();
        }
        public void ArredondaCantosdoForm()
        {

            GraphicsPath PastaGrafica = new GraphicsPath();
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, this.Size.Width, this.Size.Height));

            //Arredondar canto superior esquerdo        
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, 10, 10));
            PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

            //Arredondar canto superior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, 1, 12, 13));
            PastaGrafica.AddPie(this.Width - 24, 1, 24, 26, 270, 90);

            //Arredondar canto inferior esquerdo
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, this.Height - 10, 10, 10));
            PastaGrafica.AddPie(1, this.Height - 20, 20, 20, 90, 90);

            //Arredondar canto inferior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, this.Height - 13, 13, 13));
            PastaGrafica.AddPie(this.Width - 24, this.Height - 26, 24, 26, 0, 90);

            PastaGrafica.SetMarkers();
            this.Region = new Region(PastaGrafica);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DTO.ClienteDTO trab = new DTO.ClienteDTO();
            trab.Nome = txtnome.Text;
            trab.Telefone = mskPhone.Text;
            trab.Celular = mskCellphone.Text;
            trab.Estado = textuf.Text;
            trab.Email = txtEmail.Text;
            trab.Cep = mskCep.Text;
            trab.Cpf = mskCPF.Text;

            ClienteDatabase coursedatabase = new ClienteDatabase();
            coursedatabase.Salvar(trab);


            MessageBox.Show("Cadastro realizado com sucesso.", "Simone Ribeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtnome.Text = "";
            mskPhone.Text = "";
            mskCellphone.Text = "";
            textuf.Text = "";
            txtEmail.Text = "";
            mskCep.Text = "";
            mskCPF.Text = "";

        }

        private void Textuf_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            mskPhone.Text = "";
            mskCellphone.Text = "";
            textuf.Text = "";
            txtEmail.Text = "";
            mskCep.Text = "";
            mskCPF.Text = "";
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenu t1 = new frmMenu();
            t1.Show();
            this.Visible = false;
        }

        private void pessoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bloqueado, programa em manutenção!", "Simone Ribeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmMenu t1 = new frmMenu();
            t1.Show();
            this.Hide();
        }

        private void pessoalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            DTO.ClienteDTO trab = new DTO.ClienteDTO();
            trab.Nome = txtnome.Text;
            trab.Telefone = mskPhone.Text;
            trab.Celular = mskCellphone.Text;
            trab.Estado = textuf.Text;
            trab.Email = txtEmail.Text;
            trab.Cep = mskCep.Text;
            trab.Cpf = mskCPF.Text;

            ClienteDatabase coursedatabase = new ClienteDatabase();
            coursedatabase.Salvar(trab);


            MessageBox.Show("Cadastro realizado com sucesso.", "Simone Ribeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtnome.Text = "";
            mskPhone.Text = "";
            mskCellphone.Text = "";
            textuf.Text = "";
            txtEmail.Text = "";
            mskCep.Text = "";
            mskCPF.Text = "";
        }

        private void históricoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            mskPhone.Text = "";
            mskCellphone.Text = "";
            textuf.Text = "";
            txtEmail.Text = "";
            mskCep.Text = "";
            mskCPF.Text = "";

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmMenu t1 = new frmMenu();
            t1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
