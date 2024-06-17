using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Invitacion : Form
    {
        string respuesta;
        string host;
        public Invitacion()
        {
            InitializeComponent();
        }
        public void SetHost(string host)
        {
            this.host = host;
        }
        public string GetRespuesta()
        {
            return this.respuesta;
        }

        private void Invitacion_Load(object sender, EventArgs e)
        {
            labelInvitacion.Text = host + " te ha invitado a una partida.\n ¿Deseas unirte?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.respuesta = "SI";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.respuesta = "NO";
            this.Close();
        }
    }
}
