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
    public partial class frmConsultar2 : Form
    {
        public frmConsultar2()
        {
            InitializeComponent();
            gvConsulta.AutoGenerateColumns = false;
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

        public void CarregarTela()
        {
            ClienteDatabase db = new ClienteDatabase();
            List<ClienteDTO> c = db.Listar();

            gvConsulta.DataSource = c;
        }

        private void gvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                ClienteDTO dto = gvConsulta.Rows[e.RowIndex].DataBoundItem as ClienteDTO;

                frmEditarCliente frm = new frmEditarCliente();
                frm.Carregar(dto);
                frm.ShowDialog();
            }

            if (e.ColumnIndex == 9)
            {
                ClienteDTO dto = gvConsulta.Rows[e.RowIndex].DataBoundItem as ClienteDTO;

                ClienteDatabase db = new ClienteDatabase();
                db.Remover(dto.Id);

                MessageBox.Show("Cliente removido com sucesso.", "Simone Ribeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<ClienteDTO> list = db.Listar();

                gvConsulta.DataSource = list;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;

            ClienteDatabase cliente = new ClienteDatabase();
            List<ClienteDTO> clientes = cliente.Filtrar(nome, cpf);

            gvConsulta.DataSource = clientes;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmMenu g1 = new frmMenu();
            g1.Show();
            this.Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmMenu g1 = new frmMenu();
            g1.Show();
            this.Hide();
        }
    }
}
