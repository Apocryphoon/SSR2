using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Inicio
{
    public partial class frmLoading : Form
    {
        WMPLib.WindowsMediaPlayer meuPlayer = new WMPLib.WindowsMediaPlayer();

        public frmLoading()
        {

            InitializeComponent();
            iniciarplayer();
            desaparece();
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

        void iniciarplayer()
        {

            meuPlayer.URL = @"C:\RRAN\play.mp3";
            meuPlayer.controls.play();

        }

        void desaparece()
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            this.Opacity = 1;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ativo = true;

                if (ativo)
            {

                this.Opacity -= 0.01D;


            }

            if (this.Opacity == 0)
            {
                ativo = false;
                timer1.Enabled = false;
                frmLogin t1 = new frmLogin();
                t1.Show();

                meuPlayer.controls.stop();
                this.Hide();
            }
        }
    }
}
