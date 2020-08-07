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
 
    public partial class frmLogin : Form
    {
        public frmLogin()
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


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "Simone") &&
               (textBox2.Text == "simone1419"))
            {
                MessageBox.Show("Login, efetuado com sucesso!", "RRAN - Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMenu t1 = new frmMenu();
                t1.Show();
                this.Visible = false;

            }



            else if ((textBox1.Text == "Admin") &&
                    (textBox2.Text == "admin"))
            {
                MessageBox.Show("Administrador logado com sucesso!", "RRAN - Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMenu t1 = new frmMenu();
                t1.Show();
                this.Visible = false;
            }


            else

            {
                MessageBox.Show("Dados incorretos.", "RRAN - Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreditos t1 = new frmCreditos();
            t1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Text = "Simone";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
