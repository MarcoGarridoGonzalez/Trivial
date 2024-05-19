using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Version1proyectoS0
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;

        string usuario;
        int conectado;

        delegate void DelegadoParaEscribir(string[] conectados);

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void AtenderServidor()
        {
            while(true)
            {
                try
                {
                    byte[] mensaje = new byte[80];
                    server.Receive(mensaje);
                    string[] partes = Encoding.ASCII.GetString(mensaje).Split('/');
                    int codigo = Convert.ToInt32(partes[0]);
                    string mensaje1 = partes[1].Split('\0')[0];

                    switch(codigo)
                    {
                        case 1: // REGISTRARSE
                            if (mensaje1 == "0") 
                            {
                                MessageBox.Show("Se ha registrado correctamente.");
                            }
                            else if (mensaje1 == "1" )
                                MessageBox.Show("Este nombre de usuario ya existe.");
                            else
                                MessageBox.Show("Error de consulta, pruebe otra vez.");
                            Nombre_Re.Clear();
                            Contra_Re.Clear();
                            break;

                        case 2: //INICIO SESION
                            if (mensaje1 == "0") 
                            {
                                MessageBox.Show("Has iniciado sesión correctamente");
                            }
                             else if (mensaje1 == "1")
                            {
                                MessageBox.Show("El usuario introducido no existe");
                            }
                            else if (mensaje1 == "2")
                            {
                                MessageBox.Show("Contraseña incorrecta, vuelve a intentarlo");
                            }
                            else
                            {
                                MessageBox.Show("Error en la consulta. Pruebe otra vez.");
                            }
                            break;

                        case 3: // PETICION 1
                            if (mensaje1 == "0")
                                MessageBox.Show("La fecha de dicho jugador " + mensaje1 + "");
                            else if (mensaje1 == "-1")
                                MessageBox.Show("Error en la consulta. Pruebe otra vez.");
                            else
                                MessageBox.Show("No se han obtenido datos en la consulta.");
                            break;
                        case 4: // PETICION 2
                            if (mensaje1 == "0")
                                MessageBox.Show("El ganador de la fecha seleccionada fue:" + mensaje1 + "");
                            else if (mensaje1 == "-1")
                                MessageBox.Show("Error en la consulta. Pruebe otra vez.");
                            else
                                MessageBox.Show("No se han obtenido datos en la consulta.");
                            break;
                        case 5: // PETICION 3
                            if (mensaje1 == "-1")
                                MessageBox.Show("Error en la consulta. Pruebe otra vez.");
                            else if (mensaje1 == "-2")
                                MessageBox.Show("Estos dos jugadores nunca han jugado juntos.");
                            else
                                MessageBox.Show("Han jugado juntos un total " + mensaje1 + " de partidas");
                            break;


                    }
                }
                catch (SocketException)
                {
                    MessageBox.Show("Server desconectado");
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9200);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

    
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radio_Pet1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {


                if (Contra_Re.Text == ConfContra_Re.Text)
                {
                    string mensaje = "1/" + Nombre_Re.Text + "/" + Contra_Re.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
            string respuesta;
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            respuesta = Encoding.ASCII.GetString(msg2);
            MessageBox.Show(respuesta);
        }

        private void Iniciar_Click_1(object sender, EventArgs e)
        {
            try
            {


                string mensaje = "2/" + Nombre_In.Text + "/" + Contra_In.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
            string respuesta;
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            respuesta = Encoding.ASCII.GetString(msg2);
            MessageBox.Show(respuesta);
        }

        private void RealizarPeticion_Click_1(object sender, EventArgs e)
        {
            try
            {


                if (Peticion1.Checked)
                {
                    string mensaje = "3/" + Nombres_Pet.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    string respuesta;
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    respuesta = Encoding.ASCII.GetString(msg2);
                    MessageBox.Show(respuesta);

                }
                else if (Peticion2.Checked)
                {
                    string mensaje = "4/" + Nombres_Pet.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    string respuesta;
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    respuesta = Encoding.ASCII.GetString(msg2);
                    MessageBox.Show(respuesta);

                }
                else if (Peticion3.Checked)
                {
                    string mensaje = "5/" + Nombres_Pet.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    string respuesta;
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    respuesta = Encoding.ASCII.GetString(msg2);
                    MessageBox.Show(respuesta);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (conectado == 1)
                {
                    string mensaje = "0/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    atender.Abort();

                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }
            }
            catch (Exception) { }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Construimos el mensaje y lo enviamos (Codigo 6/ --> Dame lista conectados)
                string mensaje = "6/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "-1")
                    MessageBox.Show("No hay usuarios conectados.");
                else
                {
                    //Procesamos el mensaje para obtener un vector de conectados
                    string[] conectados = mensaje.Split('/');

                    //Queremos mostrar los datos en un Data Grid View
                    //Configuracion
                    listaconexion.Visible = true;
                    listaconexion.ColumnCount = 1;
                    listaconexion.RowCount = conectados.Length;
                    listaconexion.ColumnHeadersVisible = false;
                    listaconexion.RowHeadersVisible = false;
                    listaconexion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    listaconexion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    //Introduccion de los datos
                    for (int i = 0; i < conectados.Length; i++)
                    {
                        listaconexion.Rows[i].Cells[0].Value = conectados[i];

                    }

                    listaconexion.Show();

                }


            }

            catch (SocketException)
            {
                MessageBox.Show("Ha habido un error.");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No se puede mostrar el Data Grid View.");
            }

        }
    }
}