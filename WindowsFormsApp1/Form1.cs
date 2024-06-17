using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        Invitacion invitacion;
        List<Tablero> partidas = new List<Tablero>();
        ThreadStart ts;
        Random random = new Random();
        string texto;
        bool atenderServidor = false;
        bool conectado = false;

        int ask = 0;

        string usuario;

        List<string> invitados;

        delegate void DelegadoParaEscribir(string[] conectados);
        delegate void DelegadoParaChat(string[] conectados);

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            botonInvitar.Visible = false;
            button3.Enabled = false;
            Eliminar.Enabled = false;
            Iniciar.Enabled = false;
            Guardar.Enabled = false;
            RealizarPeticion.Enabled = false;
            chatBTN.Enabled = false;
        }
        private void AtenderServidor()
        {
            while (true)
            {
                if (atenderServidor)
                {
                    try
                    {
                        byte[] msg2 = new byte[300];
                        server.Receive(msg2);
                        string cadena = Encoding.ASCII.GetString(msg2);
                        string[] parte = Encoding.ASCII.GetString(msg2).Split(',');

                        int indiceBarra = cadena.IndexOf('/');
                        string textoDespuesBarra = cadena.Substring(indiceBarra + 1);





                        int codigo = Convert.ToInt32(parte[0]);
                        string mensaje = parte[1].Split('\0')[0];


                        switch (codigo)
                        {
                            case 0:
                                this.BackColor = Color.Gray;
                                MessageBox.Show("Te has desconectado.");
                                break;
                            case 1: // Registrarse

                                if (mensaje == "0")
                                {
                                    MessageBox.Show("Se ha registrado correctamente.");


                                }

                                //Excepciones
                                else if (mensaje == "1")
                                    MessageBox.Show("Este nombre de usuario ya existe.");

                                else
                                    MessageBox.Show("Error de consulta, pruebe otra vez.");

                                Nombre_Re.Clear();
                                Contra_Re.Clear();
                                ConfContra_Re.Clear();
                                break;
                            case 2: //Inicio Sesión
                                if (mensaje == "0")
                                {
                                    listaconexion.Visible = true;
                                    label11.Visible = true;


                                    MessageBox.Show("Has iniciado sesión correctamente");
                                    Nombre.Text = Nombre_In.Text;
                                    Nombre.BackColor = Color.White;
                                    Nombre.Visible = true;
                                    this.usuario = Nombre_In.Text;
                                    Nombre_In.Clear();
                                    Contra_In.Clear();
                                    botonInvitar.Visible = true;
                                    Iniciar.Enabled = false;
                                    chatBTN.Enabled = true;



                                }
                                //Excepciones
                                else if (mensaje == "1")
                                {
                                    MessageBox.Show("El usuario introducido no existe");
                                }
                                else if (mensaje == "2")
                                {
                                    MessageBox.Show("Contraseña incorrecta, vuelve a intentarlo");
                                }
                                else
                                {
                                    MessageBox.Show("Error en la consulta. Pruebe otra vez.");
                                }
                                break;

                            case 3: //Peticion1
                                if (mensaje == "-1")
                                    MessageBox.Show("Error de consulta. Prueba otra vez.");
                                else if (mensaje == "-2")
                                    MessageBox.Show("Este jugador nunca ha jugado.");
                                else
                                    MessageBox.Show("El usuario ha jugado los dias:" + textoDespuesBarra);
                                break;

                            case 4: //Peticion2

                                //Excepciones
                                if (mensaje == "-1")
                                {
                                    MessageBox.Show("Error de consulta. Prueba otra vez.");
                                }
                                else if (mensaje == "-2")
                                {
                                    MessageBox.Show("Ese dia no se jugo ninguna partida");
                                }

                                //Devuelve partida
                                else
                                    MessageBox.Show("El ganador de aquella partida fue:" + mensaje);
                                break;

                            case 5://Peticion3

                                if (mensaje == "-1")
                                {
                                    MessageBox.Show("Error de consulta. Prueba otra vez");
                                }
                                else
                                {
                                    MessageBox.Show("Estos usuarios han jugado juntos alguna vez.");
                                }
                                break;

                            case 6: //Notificación de actualización de la lista de conectados
                                if (mensaje == "-1")
                                    MessageBox.Show("No hay usuarios conectados.");

                                else
                                {
                                    //MessageBox.Show("Se ha actualizado la lista de conectados.");
                                    string[] conectados = mensaje.Split('*');

                                    //Delegado modifica el DataGridView para poner o quitar un usuario
                                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(ListaConectados);
                                    listaconexion.Invoke(delegado, new object[] { conectados });

                                }
                                break;
                            case 7: //Respuesta a la peticion de invitacion
                                if (mensaje == "0")
                                    MessageBox.Show("Invitaciones enviadas correctamente");
                                else
                                {
                                    //Recibimos las invitaciones fallidas
                                    string[] noDisponibles = mensaje.Split('*');
                                    string show = "";
                                    for (int n = 0; n < noDisponibles.Length; n++)
                                        show = show + noDisponibles[n] + ",";
                                    show = show.Remove(show.Length - 1);
                                    MessageBox.Show("Invitaciones enviadas con exito\n excepto las de: " + show);
                                }
                                break;
                            case 8: //Notificación de invitacion a una partida
                                string[] split = mensaje.Split('*');
                                invitacion = new Invitacion();
                                invitacion.SetHost(split[0]);
                                invitacion.ShowDialog();
                                string respuesta = "7/" + this.usuario + "/" + invitacion.GetRespuesta() + "/" + split[1] + "\0";
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                                server.Send(msg);

                                break;
                            case 9: //Notificación de inicio de partida                         
                                string[] trozo1 = mensaje.Split('|');
                                int partida = Convert.ToInt32(trozo1[0]);
                                string[] trozo = trozo1[1].Split('-');
                                string mensaje1 = trozo[0];
                                int num_jug = Convert.ToInt32(trozo[1]);
                                int jugador = Convert.ToInt32(trozo[2]);
                                ThreadStart ts = delegate { EmpezarPartida(mensaje1, partida, num_jug, jugador); };
                                Thread T = new Thread(ts);
                                T.Start();
                                break;

                            case 11:
                                string[] pieces = mensaje.Split(':');
                                pieces = mensaje.Split(':');
                                DelegadoParaChat delegadoChat = new DelegadoParaChat(PonMensaje);
                                listBox1.Invoke(delegadoChat, new object[] { pieces });
                                break;

                            case 12:
                                string[] trozos = mensaje.Split('*');
                                int id_p = Convert.ToInt32(trozos[0].Split('\0')[0]);
                                string mensaje2 = trozos[1];
                                bool encontrado = false;
                                int i = 0;
                                while (!encontrado)
                                {
                                    if (partidas[i].GetPartida() == id_p)
                                    {
                                        partidas[i].mensajePartida(codigo, mensaje2);
                                        encontrado = true;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }
                                break;

                            case 13:

                                string[] trozos1 = mensaje.Split('*');
                                int id = Convert.ToInt32(trozos1[0].Split('\0')[0]);
                                string mensaje3 = trozos1[1];
                                bool encontrado2 = false;
                                int j = 0;
                                while (!encontrado2)
                                {
                                    if (partidas[j].GetPartida() == id)
                                    {
                                        partidas[j].mensajePartida(codigo, mensaje3);
                                        encontrado2 = true;
                                    }
                                    else
                                    {
                                        j++;
                                    }
                                }
                                break;
                            case 14:
                                string[] trozos2 = mensaje.Split('*');
                                int id_part = Convert.ToInt32(trozos2[0].Split('\0')[0]);
                                string mensaje0 = trozos2[1];
                                bool encontrado0 = false;
                                int x = 0;
                                while (!encontrado0)
                                {
                                    if (partidas[x].GetPartida() == id_part)
                                    {
                                        partidas[x].mensajePartida(codigo, mensaje0);
                                        encontrado0 = true;
                                    }
                                    else
                                    {
                                        x++;
                                    }
                                }
                                break;
                            case 15:
                                if (mensaje == "0")
                                {
                                    MessageBox.Show("Usuario eliminado");
                                }
                                else if (mensaje == "-1")
                                {
                                    MessageBox.Show("Error al eliminar el usuario");
                                }

                                else if (mensaje == "1")
                                {
                                    MessageBox.Show("El usuario no existe");

                                }
                                else if (mensaje == "2")
                                {
                                    MessageBox.Show("Contraseña incorrecta");

                                }
                                else
                                {
                                    MessageBox.Show("El jugador esta conectado.");

                                }
                                Nombre_Del.Clear();
                                Contra_Del.Clear();
                                break;
                            case 16:
                                string[] partes = mensaje.Split('*');
                                int part = Convert.ToInt32(partes[0].Split('\0')[0]);
                                string msg1 = partes[1];
                                bool enc = false;
                                int y = 0;
                                while (!enc)
                                {
                                    if (partidas[y].GetPartida() == part)
                                    {
                                        partidas[y].mensajePartida(codigo, msg1);
                                        enc = true;
                                    }
                                    else
                                    {
                                        y++;
                                    }
                                }
                                break;

                        }
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Te has desconectado");
                        atenderServidor = false;
                        Nombre.Visible = false;
                        this.BackColor = Color.Gray;
                    }
                    catch { }
                }
            }
        }

        private void EmpezarPartida(string jugadores, int partida, int num_jug, int jugador)
        {
            Tablero tablero = new Tablero(partida, num_jug, jugador);
            tablero.SetPartida(jugadores, server);
            tablero.InitRandom(jugador);
            tablero.InitAleatorio(jugador, random);
            partidas.Add(tablero);
            tablero.ShowDialog();
        }
        public void PonMensaje(string[] trozos)
        {
            string nombre;
            //listBox1.Text = "---PANAS CHAT---";
            nombre = trozos[0];
            texto = trozos[1];
            texto = nombre + " : " + texto;
            listBox1.Items.Add(texto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            //IPAddress direc = IPAddress.Parse("192.168.56.102");
            //IPEndPoint ipep = new IPEndPoint(direc, 9100);

            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50007);


            //Creamos el socket 

            try
            {
                this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
                atenderServidor = true;
                ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
                Iniciar.Enabled = true;
                button3.Enabled = true;
                Eliminar.Enabled = true;
                Guardar.Enabled = true;
                RealizarPeticion.Enabled = true;
                

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(Nombre_Re.Text) && !string.IsNullOrWhiteSpace(Contra_Re.Text) && !string.IsNullOrWhiteSpace(ConfContra_Re.Text))
                {
                    if (Contra_Re.Text == ConfContra_Re.Text)
                    {
                        string mensaje = "1/" + Nombre_Re.Text + "/" + Contra_Re.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                        MessageBox.Show("Las contraseñas no coinciden");
                }
                else
                {
                    MessageBox.Show("Las credenciales son incorrectas");
                }
                    

            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Nombre_In.Text) && !string.IsNullOrWhiteSpace(Contra_In.Text))
                {
                    string mensaje = "2/" + Nombre_In.Text + "/" + Contra_In.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("El nombre o la contraseña son incorrectos");
                }
                    



            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
        }

        private void RealizarPeticion_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(Nombres_Pet.Text))
                {
                    if (Peticion1.Checked)
                    {
                        string mensaje = "3/" + Nombres_Pet.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Peticion2.Checked)
                    {
                        string mensaje = "4/" + Nombres_Pet.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                    }
                    else if (Peticion3.Checked)
                    {
                        string mensaje = "5/" + Nombres_Pet.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        MessageBox.Show("No has seleccionado ninguna pertición");
                    }
                }
                else
                {
                    MessageBox.Show("Tienes que rellenar la petición");
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
                if (atenderServidor)
                {
                    string mensaje = "0/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    atender.Abort();
                    atenderServidor = false;
                }

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                atenderServidor = false;
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                Nombre.Visible = false;
                this.BackColor = Color.Gray;
                atender.Abort();
                button3.Enabled = false;
                Eliminar.Enabled = false;
                Iniciar.Enabled = false;
                Guardar.Enabled = false;
                RealizarPeticion.Enabled = false;
                chatBTN.Enabled = false;


            }
            catch (Exception)
            {
                MessageBox.Show("Hasta pronto");
            }
        }
        public void ListaConectados(string[] conectados)
        {
            label11.Visible = true;
            listaconexion.Visible = true;
            listaconexion.ColumnCount = 1;
            listaconexion.RowCount = conectados.Length;
            listaconexion.ColumnHeadersVisible = false;
            listaconexion.RowHeadersVisible = false;
            listaconexion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            listaconexion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            listaconexion.SelectAll();

            for (int i = 0; i < conectados.Length; i++)
            {
                listaconexion.Rows[i].Cells[0].Value = conectados[i];
            }

            listaconexion.Show();

        }
        private void listaconexion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Solo funciona cuando se habilita la funcion de invitar con el boton invitarButton
            if ((botonInvitar.Text == "Enviar\n Invitación") && (invitados.Count <= 3))
            {
                string invitado = listaconexion.CurrentCell.Value.ToString();

                //Comprovamos que no somos nosotros mismos
                if (invitado == usuario)
                    MessageBox.Show("No te puedes autoinvitar");
                else
                {
                    if (invitados.Count < 4)
                    {
                        //Comprovamos que no este ya en la lista para añadirlo
                        int i = 0;
                        bool encontrado = false;
                        while ((i < invitados.Count) && (encontrado == false))
                        {
                            if (invitado == invitados[i])
                                encontrado = true;
                            else
                                i = i + 1;
                        }
                        if (encontrado == true)
                        {
                            invitados.Remove(invitado);
                            MessageBox.Show("Has eliminado a " + invitado);
                        }
                        else
                        {
                            invitados.Add(invitado);
                            MessageBox.Show("Has añadido a " + invitado);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No puedes invitar a mas jugadores");
                    }
                }
            }
            else if ((botonInvitar.Text == "Enviar\n Invitación") && (invitados.Count > 3))
                MessageBox.Show("El numero maximo de invitados es 3");
            listaconexion.SelectAll();
        }

        private void chatBTN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(chatBox.Text))
            {
                string mensaje = "8/" + this.usuario + "/" + chatBox.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                chatBox.Clear();
                
            }
            else
            {
                MessageBox.Show("No ha puesto mensaje");
            }

        }

        private void botonInvitar_Click(object sender, EventArgs e)
        {
            if (botonInvitar.Text == "Invitar")
            {
                //Iniciamos la recopilacion de invitados
                MessageBox.Show("Haz click sobre los jugadores que quieras invitar");
                botonInvitar.Text = "Enviar\n Invitación";
                invitados = new List<string>();
            }
            else
            {
                botonInvitar.Text = "Invitar";

                //si no se clica a nadie no hace nada y vuelve al estado inicial
                if (invitados.Count != 0)
                {
                    //Construimos el mensaje
                    string mensaje = "6/" + this.usuario + "/";
                    for (int i = 0; i < invitados.Count; i++)
                    {
                        mensaje = mensaje + invitados[i] + "*";
                    }

                    mensaje = mensaje.Remove(mensaje.Length - 1);

                    //Lo enviamos por el socket (Codigo 6 --> Invitar a jugadores)
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }

            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Nombre_Del.Text) && !string.IsNullOrWhiteSpace(Contra_Del.Text))
            {
                string mensaje = "12/" + Nombre_Del.Text + "/" + Contra_Del.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("El nombre o la contraseña no son validos");
            }

        }

        private void chatBox_TextChanged(object sender, EventArgs e)
        {
            chatBTN.Enabled = !string.IsNullOrWhiteSpace(chatBox.Text);
        }
    }
}
