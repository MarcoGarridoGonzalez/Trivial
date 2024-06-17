using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Preguntas : Form
    {
        Socket server;
        Thread atender;
        string pregunta;
        string respuestacorrecta;
        string tema;
        string respuestas;
        int punto;
        string host;
        bool RespuestaSeleccionada;
        Random random = new Random();
        public Preguntas()
        {
            InitializeComponent();
        }
        public void SetPregunta(string preg, string resp, string tem, string corr)
        {
            this.pregunta = preg;
            this.respuestas = resp;
            this.tema = tem;
            this.respuestacorrecta = corr;
        }

        private void Preguntas_Load(object sender, EventArgs e)
        {
            if (this.tema == "Historia")
            {
                this.BackColor = Color.Yellow;
            }
            if (this.tema == "Geografia")
            {
                this.BackColor= Color.SkyBlue;
            }
            if (this.tema == "Entretenimiento")
            {
                this.BackColor = Color.Pink;
            }
            if (this.tema == "Arte y literatura")
            {
                this.BackColor = Color.Brown;
            }
            if (this.tema == "Ciencias y naturaleza")
            {
                this.BackColor = Color.Green;
            }
            if (this.tema == "Deportes")
            {
                this.BackColor = Color.Orange;
            }
            Preguntalabel.Text =  this.pregunta;
            label1.Text = this.tema;
            string[] split = this.respuestas.Split('/');
            Uno.Text = split[0];    
            Dos.Text = split[1];
            Tres.Text = split[2];
            Cuatro.Text = split[3];

        }
        public int SetPunto()
        {
            return this.punto;
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            string respuestaseleccionada;
            if (Uno.Checked)
            {
                respuestaseleccionada = Uno.Text;
            }
            else if (Dos.Checked)
            {
                 respuestaseleccionada = Dos.Text;
            }
            else if (Tres.Checked)
            {
                 respuestaseleccionada = Tres.Text;
            }
            else if (Cuatro.Checked)
            {
                respuestaseleccionada = Cuatro.Text;
            }
            else
            {
                respuestaseleccionada = "Ninguna";
            }

            if (respuestaseleccionada == "Ninguna")
            {
                MessageBox.Show("No has elegido respuesta");
            }
            else if (respuestaseleccionada == respuestacorrecta)
            {
                RespuestaSeleccionada = true;
                MessageBox.Show("RESPUESTA CORRECTA." + respuestacorrecta + ".");
                this.punto = 1;
                this.Close();
            }
            else
            {
                RespuestaSeleccionada = true;
                MessageBox.Show("RESPUESTA INCORRECTA." + "La solucion es: " + respuestacorrecta + ".");
                this.punto = 0;
                this.Close();
            }
        }

        private void Preguntas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!RespuestaSeleccionada)
            {
                MessageBox.Show("RESPUESTA INCORRECTA." + "La solucion es: " + respuestacorrecta + ".");
            }
        }
    }
}
