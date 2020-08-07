using Inicio.DataBase;
using Inicio.DTO;
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
    public partial class frmEditarCliente : Form
    {
        public frmEditarCliente()
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

        ClienteDTO dto;
        public void Carregar(ClienteDTO dto)
        {
            this.dto = dto;

            txtnome.Text = dto.Nome;
            txtEmail.Text = dto.Email;
            mskPhone.Text = dto.Telefone;
            mskCellphone.Text = dto.Celular;
            mskCep.Text = dto.Cep;
            textuf.Text = dto.Estado;
            mskCPF.Text = dto.Cpf;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DTO.ClienteDTO trab = new DTO.ClienteDTO();
            trab.Nome = txtnome.Text;
            trab.Telefone = mskPhone.Text;
            trab.Celular = mskCellphone.Text;
            trab.Estado = textuf.Text;
            trab.Email = txtEmail.Text;
            trab.Cep = mskCep.Text;
            trab.Cpf = mskCPF.Text;

            ClienteDatabase db = new ClienteDatabase();
            db.Alterar(dto);


            MessageBox.Show("Alteraçôes salvas com sucesso.", "RRAN - Alterar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            mskPhone.Text = "";
            mskCellphone.Text = "";
            textuf.Text = "";
            txtEmail.Text = "";
            mskCep.Text = "";
            mskCPF.Text = "";
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmMenu t1 = new frmMenu();
            t1.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
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
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
