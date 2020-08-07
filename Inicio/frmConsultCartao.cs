using Inicio.DataBase;
using Inicio.DTO;
using MySql.Data.MySqlClient;
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
    public partial class frmConsultCartao : Form
    {

        //DEFINE STRING
        static string conString = "server=sql130.main-hosting.eu;SslMode=none;database=u877132465_micro;uid=u877132465_micro;pwd=91893409";

        //CONECTANDO OBJ
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd;

        public frmConsultCartao()
        {
            InitializeComponent();
            retrieve();
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

        void fill_listbox()
        {
            string constring = "datasource=sql130.main-hosting.eu;database=u877132465_micro;username=u877132465_micro;password=91893409";
            string Query = "select * from consultarcartao ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string name = myReader.GetString("nm_name");
                    string cpf = myReader.GetString("nr_cpf");
                    string email = myReader.GetString("ds_email");
                    string valor = myReader.GetString("nr_valor");
                    string vezes = myReader.GetString("nr_vezes");
                    DateTime data = myReader.GetDateTime("dt_data");



                    listBox1.Items.Add(name + ' ' + cpf + ' ' + email + ' ' + valor + ' ' + ' ' + vezes + ' ' + data);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DTOUser trab = new DTOUser();
            trab.Nome = txtnome.Text;
            trab.Cpf = maskedTextBox1.Text;
            trab.Email = txtemail.Text;
            trab.Valor = maskedTextBox2.Text;
            trab.Vezes = txtvezes.Text;
            trab.Data = dateTimePicker1.Value;

            ClienteDatabase coursedatabase = new ClienteDatabase();
            coursedatabase.Salvar(trab);


            MessageBox.Show("Cadastro realizado com sucesso.", "Simone Ribeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtnome.Text = "";
            maskedTextBox1.Text = "";
            txtemail.Text = "";
            maskedTextBox2.Text = "";
            txtvezes.Text = "";
        }

        private void retrieve()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM consultarcartao";

            try
            {

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                //RETRIEVE
                while (reader.Read())
                {

                    listBox1.Items.Add(reader["nm_name"]).ToString();

                }

                //FECHAR CONEXÃO
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            retrieve();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=sql130.main-hosting.eu;database=u877132465_micro;username=u877132465_micro;password=91893409";
            string Query = "select * from consultarcartao where nm_name='" + listBox1.Text + "' ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {

                    string name = myReader.GetString("nm_name");
                    string cpf = myReader.GetString("nr_cpf");
                    string email = myReader.GetString("ds_email");
                    string valor = myReader.GetString("nr_valor");
                    string vezes = myReader.GetString("nr_vezes");
                    DateTime data = myReader.GetDateTime("dt_data");

                    txtnome.Text = name;
                    maskedTextBox1.Text = cpf;
                    txtemail.Text = email;
                    maskedTextBox2.Text = valor;
                    txtvezes.Text = vezes;
                    dateTimePicker1.Value = data;

                    //telephone.Text = sphone;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmMenu t1 = new frmMenu();
            t1.Show();
            this.Hide();

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmPassRH t1 = new frmPassRH();
            t1.Show();
            this.Hide();

        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

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
    }
}
