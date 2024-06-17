using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Tablero : Form
    {
        int partida;
        int jugador;
        int num_jug;
        int puntuacion;
        Socket server;
        List<Point> posiciones = new List<Point>();
        List<string> jugadores;
        Random random = new Random();
        Random aleatorio = new Random();
        Preguntas preguntas;
        Form1 inicio = new Form1();
        int turno = 1;
        int pos;
        bool acabarPartida = false;
        bool ganar;
        public Tablero(int id, int numero, int jug)
        {
            InitializeComponent();
            this.partida = id;
            this.num_jug = numero;
            this.jugador = jug;


        }

        public void SetPartida(string mensaje, Socket server)
        {
            string[] trozos = mensaje.Split('*');
            this.server = server;

            jugadores = new List<string>();
            for (int i = 0; i < trozos.Length; i++)
                jugadores.Add(trozos[i]);

        }
        public int GetPartida()
        {
            return this.partida;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Tablero_Load(object sender, EventArgs e)
        {
            Rojo.Visible = false;
            Azul.Visible = false;
            Verde.Visible = false;
            Amarillo.Visible = false;
            Dado1.Visible = false;
            Dado2.Visible = false;
            Dado3.Visible = false;
            Dado4.Visible = false;
            Dado5.Visible = false;
            Dado6.Visible = false;

            this.puntuacion = 0;


            this.BackColor = Color.DarkCyan;
            posiciones.Add(new Point(120, 55));    //Azul
            posiciones.Add(new Point(156, 34));    //Rosa
            posiciones.Add(new Point(185, 26));    //Blanco
            posiciones.Add(new Point(215, 18));    //Amarillo
            posiciones.Add(new Point(245, 18));    //Marron
            posiciones.Add(new Point(270, 26));    //Blanco
            posiciones.Add(new Point(300, 34));    //Verde
            posiciones.Add(new Point(340, 50));    //Naranja
            posiciones.Add(new Point(375, 78));    //Verde
            posiciones.Add(new Point(395, 98));    //Blanco
            posiciones.Add(new Point(415, 121));   //Rosa
            posiciones.Add(new Point(432, 147));   //Azul
            posiciones.Add(new Point(445, 175));   //Blanco
            posiciones.Add(new Point(452, 205));   //Marron
            posiciones.Add(new Point(457, 250));   //Amarillo
            posiciones.Add(new Point(455, 295));   //Marron
            posiciones.Add(new Point(445, 325));   //Blanco  
            posiciones.Add(new Point(437, 355));   //Verde   
            posiciones.Add(new Point(420, 382));   //Naranja   
            posiciones.Add(new Point(400, 410));   //Blanco  
            posiciones.Add(new Point(380, 430));   //Azul
            posiciones.Add(new Point(345, 455));   //Rosa 
            posiciones.Add(new Point(305, 475));   //Azul   
            posiciones.Add(new Point(280, 490));   //Blanco   
            posiciones.Add(new Point(250, 500));   //Marron
            posiciones.Add(new Point(215, 500));   //Amarillo
            posiciones.Add(new Point(185, 490));   //Blanco         
            posiciones.Add(new Point(155, 475));   //Naranja    
            posiciones.Add(new Point(120, 460));   //Verde
            posiciones.Add(new Point(80, 435));    //Naranja
            posiciones.Add(new Point(55, 410));    //Blanco 
            posiciones.Add(new Point(45, 385));    //Azul   
            posiciones.Add(new Point(25, 360));    //Rosa 
            posiciones.Add(new Point(15, 320));    //Blanco
            posiciones.Add(new Point(10, 280));    //Amarillo
            posiciones.Add(new Point(5, 260));     //Marron
            posiciones.Add(new Point(8, 210));     //Amarillo   
            posiciones.Add(new Point(15, 180));    //Blanco   
            posiciones.Add(new Point(25, 150));    //Naranja
            posiciones.Add(new Point(40, 125));    //Verde
            posiciones.Add(new Point(60, 100));    //Blanco         
            posiciones.Add(new Point(80, 75));     //Rosa   



            playersGridView.ColumnCount = 3;
            playersGridView.RowCount = this.jugadores.Count;
            playersGridView.ColumnHeadersVisible = true;
            playersGridView.Columns[0].HeaderText = "Jugador";
            playersGridView.Columns[1].HeaderText = "Turno";
            playersGridView.Columns[2].HeaderText = "Puntos";
            playersGridView.RowHeadersVisible = false;
            playersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            playersGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            playersGridView.SelectAll();

            //for(int i = 0; i<this.invitados.Count; i++)
            for (int i = 0; i < this.jugadores.Count; i++)
            {
                //playersGridView.Rows[i].Cells[0].Value = invitados[i];
                playersGridView.Rows[i].Cells[0].Value = jugadores[i];
                playersGridView.Rows[i].Cells[1].Value = "NO";
                playersGridView.Rows[i].Cells[2].Value = "0";
            }
            playersGridView.Rows[0].Cells[1].Value = "SI";
            playersGridView.Show();
            panel1.Controls.Add(Rojo);
            Rojo.Text = jugadores[0];
            Rojo.BackColor = Color.Red;
            Rojo.Location = posiciones[0];
            Rojo.Visible = true;

            if (this.num_jug >= 2)
            {
                panel1.Controls.Add(Azul);
                Azul.Text = jugadores[1];
                Azul.BackColor = Color.SkyBlue;
                Azul.Location = posiciones[21];
                Azul.Visible = true;
            }
            if (this.num_jug >= 3)
            {
                panel1.Controls.Add(Verde);
                Verde.Text = jugadores[2];
                Verde.BackColor = Color.Green;
                Verde.Location = posiciones[14];
                Verde.Visible = true;
            }
            if (this.num_jug >= 4)
            {
                panel1.Controls.Add(Amarillo);
                Amarillo.Text = jugadores[3];
                Amarillo.BackColor = Color.Yellow;
                Amarillo.Location = posiciones[35];
                Amarillo.Visible = true;
            }
            if (this.jugador == 1)
            {
                this.pos = 0;
            }
            if (this.jugador == 2)
            {
                this.pos = 21;
            }
            if (this.jugador == 3)
            {
                this.pos = 14;
            }
            if (this.jugador == 4)
            {
                this.pos = 35;
            }
            label1.Text = jugadores[this.jugador - 1];
        }
        public void mensajePartida(int codigo, string mensaje)
        {
            switch (codigo)
            {
                case 12:

                    string[] trozos = mensaje.Split('/');
                    int jug;
                    int posicion;
                    int turn;
                    turn = Convert.ToInt32(trozos[0]);
                    jug = Convert.ToInt32(trozos[1]);
                    posicion = Convert.ToInt32(trozos[2]);
                    int puntos = Convert.ToInt32(trozos[3]);
                    NuevoMovimiento(turn, jug, posicion, puntos);


                    break;
                case 13:
                    if (mensaje == "0")
                    {
                        string mensaje1 = "9/" + this.partida + "/" + this.turno + "/" + this.jugador + "/" + this.pos + "/" + this.puntuacion;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                        server.Send(msg);
                        break;
                    }
                    else
                    {
                        string[] trozo = mensaje.Split('|');
                        string tema;
                        string respuestas;
                        string correcta;
                        string pregunta;
                        tema = trozo[0];
                        pregunta = trozo[1];
                        correcta = trozo[2];
                        respuestas = trozo[3];
                        preguntas = new Preguntas();
                        preguntas.SetPregunta(pregunta, respuestas, tema, correcta);
                        preguntas.ShowDialog();
                        int punto = preguntas.SetPunto();
                        this.puntuacion = this.puntuacion + punto;
                        string mensaje1;
                        if (this.puntuacion == 10)
                        {
                            DateTime fecha = DateTime.Today;
                            string año = fecha.Year.ToString();
                            string mes = fecha.Month.ToString();
                            string dia = fecha.Day.ToString();
                            string data = dia + "-" + mes + "-" + año;
                            mensaje1 = "13/" + this.partida + "/" + this.jugador + "/" + data;
                            ganar = true;
                        }
                        else
                        {
                            mensaje1 = "9/" + this.partida + "/" + this.turno + "/" + this.jugador + "/" + this.pos + "/" + this.puntuacion;
                            
                        }
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                        server.Send(msg);
                        break;
                    }
                case 14:
                    string[] trozos2 = mensaje.Split('/');
                    int j = Convert.ToInt32(trozos2[0]);
                    if (this.jugador != j)
                    {

                        this.turno = 1;
                        this.num_jug = Convert.ToInt32(trozos2[1]);
                        MessageBox.Show(jugadores[j - 1] + " se ha salido de la partida");
                        jugadores.RemoveAt(j - 1);
                        if (this.num_jug < 2)
                        {
                            MessageBox.Show("No hay suficientes jugadores en la partida");
                            this.Close();
                        }
                        else
                        {
                            if (this.jugador > j)
                            {
                                this.jugador = this.jugador - 1;
                            }
                            if (num_jug == 2)
                            {
                                Verde.Visible = false;
                                Rojo.Text = jugadores[0];
                                Azul.Text = jugadores[1];
                                if (j == 1)
                                {
                                    Rojo.Location = Azul.Location;
                                    Azul.Location = Verde.Location;
                                }
                                if (j == 2)
                                {
                                    Azul.Location = Verde.Location;
                                }
                            }
                            if (num_jug == 3)
                            {
                                Amarillo.Visible = false;
                                Rojo.Text = jugadores[0];
                                Azul.Text = jugadores[1];
                                Verde.Text = jugadores[2];
                                if (j == 1)
                                {
                                    Rojo.Location = Azul.Location;
                                    Azul.Location = Verde.Location;
                                    Verde.Location = Amarillo.Location;
                                }
                                if (j == 2)
                                {
                                    Azul.Location = Verde.Location;
                                    Verde.Location = Amarillo.Location;
                                }
                                if (j == 3)
                                {
                                    Verde.Location = Amarillo.Location;
                                }

                            }
                            playersGridView.Rows.RemoveAt(j - 1);
                            playersGridView.Rows[0].Cells[1].Value = "SI";
                            for (int i = 1; i < this.num_jug; i++)
                            {
                                playersGridView.Rows[i].Cells[1].Value = "NO";
                            }

                        }
                    }
                    break;
                case 16:
                    acabarPartida = true;
                    int idP = Convert.ToInt32(mensaje);
                    string mensaje2 = "14/" + this.partida + "/" + idP + "/" + this.jugador + "/"  + this.puntuacion;
                    byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg2);
                    if (ganar == true)
                    {
                        MessageBox.Show("Has ganado.");
                    }
                    else
                    {
                        MessageBox.Show("Has perdido.");
                    }
                    this.Close();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.jugador == this.turno)
            {
                int num = random.Next(1, 6);
                Dado1.Visible = false;
                Dado2.Visible = false;
                Dado3.Visible = false;
                Dado4.Visible = false;
                Dado5.Visible = false;
                Dado6.Visible = false;
                if (num == 1)
                {
                    Dado1.Visible = true;
                }
                if (num == 2)
                {
                    Dado2.Visible = true;
                }
                if (num == 3)
                {
                    Dado3.Visible = true;
                }
                if (num == 4)
                {
                    Dado4.Visible = true;
                }
                if (num == 5)
                {
                    Dado5.Visible = true;
                }
                if (num == 6)
                {
                    Dado6.Visible = true;
                }
                for (int i = 0; i < num; i++)
                {
                    this.pos++;
                    if (this.pos > 41)
                    {
                        this.pos = 0;
                    }
                }
                this.turno++;
                if (turno > this.num_jug)
                {
                    turno = 1;
                }
                if ((this.pos == 0) || (this.pos == 11) || (this.pos == 20) || (this.pos == 22) || (this.pos == 31))  // Casillas Azules   
                {
                    string tema = "Geografia";
                    int id = aleatorio.Next(1, 15);
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);
                }
                else if ((this.pos == 1) || (this.pos == 10) || (this.pos == 21) || (this.pos == 32) || (this.pos == 41)) // Casillas Rosas
                {
                    string tema = "Entretenimiento";
                    int id = aleatorio.Next(46, 60);
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);

                }
                else if ((this.pos == 3) || (this.pos == 14) || (this.pos == 25) || (this.pos == 34) || (this.pos == 36)) // Casillas Amarillas
                {
                    string tema = "Historia";
                    int id = aleatorio.Next(31, 45);
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);

                }
                else if ((this.pos == 4) || (this.pos == 13) || (this.pos == 15) || (this.pos == 24) || (this.pos == 35)) // Casillas Marrones
                {
                    string tema = "Arte y literatura";
                    int id = aleatorio.Next(16, 30);
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);
                }
                else if ((this.pos == 6) || (this.pos == 8) || (this.pos == 17) || (this.pos == 28) || (this.pos == 39)) // Casillas Verdes
                {
                    string tema = "Ciencias y naturaleza";
                    int id = aleatorio.Next(61, 75);
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);

                }
                else if ((this.pos == 7) || (this.pos == 18) || (this.pos == 27) || (this.pos == 29) || (this.pos == 38)) // Casillas Naranjas
                {
                    string tema = "Deportes";
                    int id = aleatorio.Next(76, 90);
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);

                }
                else
                {
                    MessageBox.Show("Pierdes el turno");
                    string tema = "Ninguno";
                    int id = 0;
                    string mensaje1 = "10/" + this.partida + "/" + tema + "/" + id;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje1);
                    server.Send(msg);
                }



            }
            else
            {
                MessageBox.Show("No es tu turno");
            }
        }
        public void NuevoMovimiento(int turn, int jug, int posicion, int puntos) //"idPartida*resDado*nombreTirador*siguienteTurno(rol)"
        {
            this.turno = turn;
            for (int i = 1; i <= this.num_jug; i++)
            {
                if (i == turn)
                {
                    playersGridView.Rows[i - 1].Cells[1].Value = "SI";

                }
                else
                {
                    playersGridView.Rows[i - 1].Cells[1].Value = "NO";
                }
            }
            playersGridView.Rows[jug - 1].Cells[2].Value = Convert.ToString(puntos);
            if (jug == 1)
            {
                Rojo.Location = posiciones[posicion];
            }
            if (jug == 2)
            {
                Azul.Location = posiciones[posicion];
            }
            if (jug == 3)
            {
                Verde.Location = posiciones[posicion];
            }
            if (jug == 4)
            {
                Amarillo.Location = posiciones[posicion];
            }
            if (this.jugador == turn)
            {
                MessageBox.Show("Tu turno");
            }


        }

        private void Tablero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.num_jug >= 2 && !acabarPartida)
            {
                int num = this.num_jug - 1;
                string mensaje = "11/" + this.partida + "/" + this.jugador + "/" + num;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void Abandonar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal void InitRandom(int jugador)
        {
            this.random = new Random(jugador);
        }
        internal void InitAleatorio(int jugador, Random random)
        {
            int i = random.Next(0, 100);
            this.aleatorio = new Random(jugador + i);
        }


    }
}
