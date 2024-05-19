#include <stdio.h>
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <sys/types.h>
#include <unistd.h>
#include <ctype.h>
#include <pthread.h>

MYSQL *conn;
typedef struct{
	char nombre[25];
	int *socket;
}Jugador;

typedef struct{
	Jugador conectados[50];
	int num;
}ListaConectados;

typedef struct{
	int estado;
	int numInvitados;
	char host[25];
	char jug2[25];
	char jug3[25];
	char jug4[25];
}Partidas;

ListaConectados listaC;
int len_tablaP=100;
Partidas tablaP[100];


int i;
int sockets[100];

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int DameGanador(char fecha[20], char ganador[250])
{

	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[250];
	//"SELECT j.nombre AS ganador \
           FROM jugadores j \
           JOIN informacion i ON j.id_jugador = i.id_jugador \
           JOIN partidas p ON i.id_partida = p.id_partida \
           WHERE p.fecha = 'fecha_deseada' \
           ORDER BY i.posicion ASC \
           LIMIT 1;";
	sprintf (consulta, "SELECT jugador.username FROM jugador JOIN informacion ON jugador.id = informacion.id_j JOIN partida ON informacion.id_p = partida.id WHERE partida.fecha= '%s' ORDER BY informacion.posicion ASC LIMIT 1;",fecha);
	//strcpy (consulta, "SELECT jugador.username FROM jugador,partida,informacion WHERE partida.fecha = '");
	//strcat (consulta,fecha);
	//strcat (consulta, "'AND informacion.posicion=1 AND partida.id = informacion.id_p AND informacion.id_j = jugador.id");
	err = mysql_query (conn, consulta);
	if (err != 0) {
		return -1;

	}
	else{
		
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL){
			return -2;
		}
		else{
			
			while (row != NULL){
				printf("%s", row[0]);
				sprintf(ganador,"%s -- %s",ganador,row[0]);
				row = mysql_fetch_row (resultado);
			}
			for (int i= 0; i < strlen(fecha)-2; i++){
				fecha[i] = fecha[i + 2];
			}
			int len = strlen(fecha);
			fecha[len - 1] = '\0';
			fecha[len - 2] = '\0';
			return 0;
			}
			
	}
}

int DameFecha(char nombre[20], char fecha[250])
{

	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[250];
	strcpy (consulta, "SELECT partida.fecha FROM jugador,partida,informacion WHERE jugador.username = '");
	strcat (consulta,nombre);
	strcat (consulta, "'AND partida.id = informacion.id_p  AND informacion.id_j = jugador.id");
	err = mysql_query (conn, consulta);
	if (err != 0) {
		return -1;
	}
	else{
	
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL){
			return -2;
		}
		else{
			while (row != NULL){
				sprintf(fecha,"%s -- %s",fecha,row[0]);
				row = mysql_fetch_row (resultado);
			}
			for (int i= 0; i < strlen(fecha)-2; i++){
				fecha[i] = fecha[i + 2];
			}
			int len = strlen(fecha);
			fecha[len - 1] = '\0';
			fecha[len - 2] = '\0';
			return 0;
			}
			
	}
	
}

int PartidasEntreEllos(char jugador1[20], char jugador2[20]) 
	
{ 
	
	int contador;
	int err; 
	// Estructura especial para almacenar resultados de consultas  
	
	MYSQL_RES *resultado; 
	MYSQL_ROW row; 
	char consulta1[250];
	char consulta2[250];
	
	sprintf (consulta1,"SELECT count(partida.id) FROM jugador,partida,informacion WHERE jugador.username = '%s' AND partida.id IN (SELECT partida.id FROM jugador,partida,informacion where jugador.username = '%s' AND jugador.id = informacion.id_j AND informacion.id_p = partida.id)", jugador1, jugador2);
	err=mysql_query (conn, consulta1);
	if (err !=0) { 
		return -1;
		
	}
	else{
		
		resultado = mysql_store_result (conn);
		row=mysql_fetch_row (resultado);


		while (row != NULL){
			contador = atoi(row[0]);
			row = mysql_fetch_row(resultado);
			
		}
			return contador;
	}
}

int Registrarse(char username[20], char password[20])
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta[100];
	strcpy(consulta, "SELECT username FROM jugador WHERE username='");
	strcat(consulta,username);
	strcat(consulta, "'");
	
	err = mysql_query(conn, consulta);
	if(err!=0)
		return -1;
	else
	{
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		
		if(row==NULL)
		{
			err = mysql_query(conn, "SELECT * FROM jugador WHERE id IN (SELECT max(id) FROM jugador);");
			if(err!=0)
			{
				return -1;
			}
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			printf("%s\n", row[0]);
			int id = atoi(row[0])+ 1;
			sprintf(consulta,"INSERT INTO jugador VALUES (%d, '%s', '%s');", id,username,password);
			printf("%s\n",consulta);
			err = mysql_query(conn,consulta);
			if(err!=0)
				return -1;
			else
			   return 0;
		}
		else 
			return 1;
	}
}

int IniciarSesion (char username[20], char password[20])
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta[100];
	strcpy(consulta, "SELECT contraseña FROM jugador WHERE username='");
	strcat(consulta,username);
	strcat(consulta, "'");
	err = mysql_query(conn,consulta);
	if(err!=0)
	{
		printf("Error al consultar la informacion en la base de datos %u %s", mysql_errno(conn),mysql_error(conn));
		return -1;
	}
	else
	{
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		if(row==NULL)
			return 1;
		else
		{
			printf("%s\n", row[0]);
			if(strcmp(password,row[0])==0){
				int i=0;
				int encontrado=0;
				while(i<listaC.num && encontrado==0){
					if (strcmp(listaC.conectados[i].nombre,username)==0)
						encontrado = 1;
					else
						i=i+1;
				}
				if (encontrado==1)
					return 3;
				else
					return 0;
			}
			else
				return 2;
		}
	}
}
int DameListaConectados(char list[512])
{
	strcpy(list, "\0");
	if (listaC.num!=0)
	{
		int i;
		for(i=0; i< listaC.num; i++)
			sprintf(list, "%s%s*", list, listaC.conectados[i].nombre);
		list[strlen(list)-1]='\0';
		return 0;
	}
	else 
		return -1;
} 
void AnadirAListaConectados (char nombre[25],int *socket){
	
	if (nombre != NULL && socket != NULL){
		//Creamos un nuevo usuario que añadir a la lista
		Jugador nuevoJugador;
		strcpy(nuevoJugador.nombre,nombre);
		nuevoJugador.socket = socket;
		
		//Lo añadimos
		listaC.conectados[listaC.num]=nuevoJugador;
		listaC.num = listaC.num+1;
		printf("Usuario %s añadido", nombre);
	}	
}
void RetirarDeListaConectados (char nombre[25]) {
	
	if (nombre != NULL){
		int n = 0;
		int encontrado = 0;
		
		while(n<listaC.num && encontrado==0){
			if (strcmp(listaC.conectados[n].nombre,nombre)==0){
				encontrado = 1;
			}
			else
				n++;
		}
		if (encontrado==1){
			while(n<listaC.num){
				listaC.conectados[n]=listaC.conectados[n+1];
				n++;
			}
			listaC.num = listaC.num-1;
		}
	}
}


void NotificarNuevaListaConectados(){
	
	char lista[512];
	char notificacion[512];
	
	//pthread_mutex_lock(&mutex);
	int res = DameListaConectados(lista);
	//pthread_mutex_unlock(&mutex);
	
	printf("Notificacion de actualizacion de ListaConectados\n");
	if (res == 0){
		printf("Lista de conectados con nuevos datos\n");
		sprintf(notificacion,"6/%s",lista);
	}
	else{
		printf("Lista de conectados vacia\n");
		sprintf(notificacion,"6/%s",lista);
	}
	
	//Envia actualización a todos los sockets
	int j;
	for (j=0;j<listaC.num;j++){
		write(listaC.conectados[j].socket,notificacion,strlen(notificacion));
	}
	
}
int DameSocketConectado(char nombre[25]){
	//Retorna -1 --> El usuario buscado no se ha encontrado conectado.
	//Retorna número socket--> Se ha encontrado el resultado conectado.
	int i=0;
	int encontrado=0;
	while (i<listaC.num && !encontrado){
		if (strcmp(listaC.conectados[i].nombre,nombre)==0)
			encontrado=1;
		else
			i++;
	}
	if (encontrado==1)
	{
		return listaC.conectados[i].socket;
	}
	else 
		return -1;
}

int Invitar(char invitados[500], char nombre[25], char noDisponibles[500],int partida) {
	//invitados; nombre: quien invita
	//Retorna numero de invitados --> Todo OK (+ notifica a los invitados (8/persona_que_le_ha_invitado*id_partida))
	//       -1 --> Alguno de los usuarios invitados se ha desconectado (+nombres de los desconectados en noDisponibles)
	
	strcpy(noDisponibles,"\0");
	int error = 0;
	char *p = strtok(invitados,"*");
	int numInvitados = 0;
	
	while (p != NULL) {
		int encontrado = 0;
		int i = 0;
		while ((i<listaC.num)&&(encontrado == 0)) {
			if (strcmp(listaC.conectados[i].nombre,p) == 0) {
				char invitacion[512];
				sprintf(invitacion, "8/%s*%d*", nombre,partida);
				//Invitacion: 8/quien invita*id_partida
				printf("Invitacion: %s\n",invitacion);
				write(listaC.conectados[i].socket, invitacion, strlen(invitacion));
				encontrado = 1;
				numInvitados = numInvitados +1;
			}
			else
				i = i + 1;
		}
		if (encontrado == 0){
			error = -1;
			sprintf(noDisponibles,"%s%s*",noDisponibles,p);
			noDisponibles[strlen(noDisponibles)-1] = '\0';
		}
		p = strtok(NULL, "*");		
	}
	if(error == 0){
		error = numInvitados;
		pthread_mutex_lock(&mutex);
		tablaP[partida].numInvitados = numInvitados;
		pthread_mutex_unlock(&mutex);
	}
	
	return error;
}
//Busca una partida disponible en la tabla de partidas y le asocia el  host
int CrearPartida(char nombre[25]){
//int CrearPartida(char invitados[500], char nombre[25]){
	//Retorna -1 --> si no hay ningún espacio libre en la tabla de partidas.
	//Retorna id de la partida-->  si se ha asignado.
	int i=0;
	int encontrado=0;
	while((i<len_tablaP)&&!encontrado)
	{	
		pthread_mutex_lock(&mutex);
		if(tablaP[i].estado==0)
		{
			strcpy(tablaP[i].host,nombre);
			tablaP[i].estado=1;
			printf("Estado partida %d: %d\n",i, tablaP[i].estado);
			strcpy(tablaP[i].jug2,"0");
			strcpy(tablaP[i].jug3,"0");
			strcpy(tablaP[i].jug4,"0");
			encontrado=1;
		}
		else 
		   i++;
		pthread_mutex_unlock(&mutex);
		
	}
	if(encontrado==0)
		return -1;
	else{
		return i;
	}
}
//Añade un jugador a la partida indicada
int AnadirJugador(char nombre[25],int partida){
	//Retorna numero de jugadores que faltan para aceptar
	//Cliente ya no permite que se inviten a mas de 3 personas
	printf("Añadir jugador: %s\n",nombre);
	pthread_mutex_lock(&mutex);
	if(strcmp(tablaP[partida].jug2,"0")==0){
		strcpy(tablaP[partida].jug2,nombre);
	}
	else if (strcmp(tablaP[partida].jug3,"0")==0)
		strcpy(tablaP[partida].jug3,nombre);
	else if(strcmp(tablaP[partida].jug4,"0")==0)
		strcpy(tablaP[partida].jug4,nombre);

	tablaP[partida].numInvitados = tablaP[partida].numInvitados-1;
	int res = tablaP[partida].numInvitados;
	pthread_mutex_unlock(&mutex);
	return res;	
}

void IniciarPartida (int partida, char jugadores_partida[500]){
	char ini[200];
	char ini1[200];
	char ini2[200];
	char ini3[200];
	char ini4[200];
	sprintf(ini, "9/%d*%s", partida, jugadores_partida);
	sprintf(ini1, "%s-1", ini);
	sprintf(ini2, "%s-2", ini);
	sprintf(ini3, "%s-3", ini);
	sprintf(ini4, "%s-4", ini);
	printf("Iniciar partida: %s\n",ini);
	int socket1 = DameSocketConectado(tablaP[partida].host);
	if(socket1!=-1)
		write(socket1,ini1,strlen(ini1));
	int socket2 = DameSocketConectado(tablaP[partida].jug2);
	if(socket2!=-1)
		write(socket2,ini2,strlen(ini2));
	
	if (strcmp(tablaP[partida].jug3,"0")!=0){
		int socket3=DameSocketConectado(tablaP[partida].jug3);
		if(socket3!=-1)
			write(socket3,ini3,strlen(ini3));
	}
	if (strcmp(tablaP[partida].jug4,"0")!=0){
		int socket4=DameSocketConectado(tablaP[partida].jug4);
		if(socket4!=-1)
			write(socket4,ini4,strlen(ini4));
	}	
}
//Notifica a los jugadores de la tabla que ha acabado la partida.
void FinPartida(int partida){
	char fin[20];
	sprintf(fin,"10/%d", partida);
	int socket1=DameSocketConectado(tablaP[partida].host);
	if(socket1!=-1){
		write(socket1,fin,strlen(fin));
		printf("notificación: %s enviada a socket:%d \n",fin,socket1);
	}
	int socket2=DameSocketConectado(tablaP[partida].jug2);
	if (socket2!=-1){
		write(socket2,fin,strlen(fin));
		printf("notificación: %s enviada a socket:%d \n",fin,socket2);
	}
	
	if (strcmp(tablaP[partida].jug3,"0")!=0){
		int socket3=DameSocketConectado(tablaP[partida].jug3);
		if(socket3!=-1)
		{
			write(socket3,fin,strlen(fin));
			printf("notificación: %s enviada a socket:%d \n",fin,socket3);
		}	
	}
	if (strcmp(tablaP[partida].jug4,"0")!=0){
		int socket4=DameSocketConectado(tablaP[partida].jug4);
		if(socket4!=-1){
			write(socket4,fin,strlen(fin));
			printf("notificación: %s enviada a socket:%d \n",fin,socket4);
			
		}
	}	
}
//Eliminia una partida de la tabla de partidas.
void EliminarPartida(int partida){
	tablaP[partida].estado=0;
	tablaP[partida].numInvitados=-1;
	strcpy(tablaP[partida].host,"0");
	strcpy(tablaP[partida].jug2,"0");
	strcpy(tablaP[partida].jug3,"0");
	strcpy(tablaP[partida].jug4,"0");
}

void DameJugadoresPartida(int partida, char jugadores[500]){
	sprintf(jugadores,"%s*%s",tablaP[partida].host,tablaP[partida].jug2);
	int cont = 2;
	if (strcmp(tablaP[partida].jug3,"0")!=0){
		sprintf(jugadores,"%s*%s",jugadores,tablaP[partida].jug3);
		cont++;
		if(strcmp(tablaP[partida].jug4,"0")!=0){
		sprintf(jugadores,"%s*%s",jugadores,tablaP[partida].jug4);
		cont++;
		}
	}
	sprintf(jugadores,"%s-%d",jugadores,cont);
}
//Retorna los id de las partidas en las que participa el jugador recibido como parámetro
void DamePartidasJugador(char nombre[25], char partidas[100]){
	int i=0;
	strcpy(partidas,"\0");
	while(i<len_tablaP)
	{
		if((strcmp(nombre,tablaP[i].host)==0)||(strcmp(nombre,tablaP[i].jug2)==0)||(strcmp(nombre,tablaP[i].jug3)==0)||(strcmp(nombre,tablaP[i].jug4)==0))
			sprintf(partidas,"%s%d/",partidas,i);
		i=i+1;
	}
}

int *AtencionClientes(void *socket){
	
	char peticion[512];
	char respuesta[512];
	
	int ret;
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	
	int terminar = 0;
	while(terminar == 0)
	{
		ret = read(sock_conn,peticion,sizeof(peticion));
		printf("Recibida una peticion\n");
		
		
		printf("La peticion es: %s\n", peticion);
		peticion[ret]='\0';
		
	
		char nombre[20];
		char password[20];
		char fecha[250];
		char nombre2[20];
		
		char *p = strtok(peticion, "/");
		int codigo = atoi(p);
		
		
		if(codigo==0)
		{
			terminar = 1;
			
			pthread_mutex_lock(&mutex);
			RetirarDeListaConectados(nombre);
			NotificarNuevaListaConectados();
			char partidas[100];
			DamePartidasJugador(nombre,partidas);
			char *p=strtok(partidas,"/");
			while(p!=NULL)
			{	
				int partida=atoi(p);
				FinPartida(partida);
				printf("Notificación de fin de partida %d\n",partida);
				EliminarPartida(partida);
				p=strtok(NULL,"/");
			}
						
			pthread_mutex_unlock(&mutex);
			
			
		}
		else if(codigo==1) //REGISTRARSE
		{
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok (NULL, "/");
			strcpy (password, p);

				
			int res = Registrarse(nombre,password);
			sprintf(respuesta,"1/%d",res);
			
		}
		else if(codigo==2) //INICIO SESION
		{
			p = strtok(NULL,"/");
			strcpy(nombre,p);
				p = strtok(NULL,"/");
			strcpy(password,p);
				
			int res = IniciarSesion(nombre,password);
			sprintf(respuesta,"2/%d", res);
				
				//Añadimos a la lista de conectados si todo ha ido bien
			if (res == 0){
				pthread_mutex_lock(&mutex);  //Autoexclusion
				AnadirAListaConectados(nombre,sock_conn);
				NotificarNuevaListaConectados();
				pthread_mutex_unlock(&mutex);
					
					
			}
		}
		else if(codigo==3)
		{
			p = strtok(NULL,"/");
			strcpy(nombre,p);

				
			int res = DameFecha(nombre,fecha);
			if (res ==0)
				sprintf(respuesta,"3/%s",fecha);
			else
				sprintf(respuesta,"3/%d",res);
			
		}
		else if(codigo==4)
		{
			p = strtok(NULL, "/");
			strcpy(fecha,p);
			char ganador[250];
			
			int res = DameGanador(fecha, ganador);
			if (res == 0){
				sprintf(respuesta,"4/%s",ganador);
			}
			else{
				sprintf(respuesta,"4/%d",res);
			}
		}
		else if(codigo==5)
		{
			p = strtok(NULL,"/");
			strcpy(nombre,p);
			p = strtok(NULL,"/");
			strcpy(nombre2,p);
			
			int res = PartidasEntreEllos(nombre, nombre2);
			
			sprintf(respuesta,"5/%d",res);
		
		}
		else if (codigo ==  6) {
				//Mensaje en peticion: 6/invitado1*invitado2*...
				//Return en respuesta: 7/0 (Todo OK) ; 7/invitado_no_disponible1/... (si hay invitados que se han desconectado)
				
				p = strtok(NULL, "/");
				char invitados[500];
				printf("Invitados: %s\n", invitados);
				char noDisponibles[500];
				strcpy(invitados, p);
								
				int partida=CrearPartida(nombre);
				if (partida==-1)
					sprintf(respuesta,"7/-1");
				else
					{
					int res = Invitar(invitados, nombre, noDisponibles,partida);
					printf("Resultado de invitar: %d\n",res);
					
					if (res == -1){
						sprintf(respuesta,"7/%s",noDisponibles);
					}
					else{
						strcpy(respuesta,"7/0");						 
					}
				}
				
			}
			//Codigo 7 --> Respuesta a una invitacion de partida
		else if (codigo ==  7) {
			//Mensaje en peticion: 7/respuesta(SI/NO)/id_partida
			//Mensaje en respuesta: -
				
			p = strtok(NULL,"/");
			char respuesta1[3];
			strcpy(respuesta1,p);
			printf("%s\n",respuesta1);
			p = strtok(NULL,"/");
			printf("Id partida: %s\n",p);
			int id_partida;
			id_partida = atoi(p);
			if (strcmp(respuesta1,"NO")==0){
				FinPartida(id_partida);
				EliminarPartida(id_partida);
			}
			else{
				int res = AnadirJugador(nombre,id_partida);
				printf("Añadido a la partida %s\n",nombre);
				printf("%d\n",res);
				if (res == 0){
					printf("Iniciar partida: \n");
					char jugadores_partida[500];
					DameJugadoresPartida(id_partida,jugadores_partida);
					IniciarPartida(id_partida,jugadores_partida);
				}
			}
				
		}
	    else if (codigo == 8)
		{
			int sock;
			char usuario[20];
			p=strtok(NULL, "/");
			strcpy(usuario,p);
			
			char mensaje[200];
			p=strtok(NULL, "/");
			strcpy(mensaje,p);
			
			sprintf(respuesta, "11/%s:%s", usuario, mensaje);
			
			sock = DameSocketConectado(usuario);
			for (int i=0; i<listaC.num ; i++)
			{
				write (listaC.conectados[i].socket, respuesta , strlen(respuesta));
			}
		}
		else if (codigo == 9)
		{
			p = strtok(NULL,"/");
			int partida;
			partida = atoi(p);
			p = strtok(NULL,"/");
			int turno;
			turno = atoi(p);
			p = strtok(NULL,"/");
			int jugador;
			jugador = atoi(p);
			p = strtok(NULL,"/");
			int pos;
			pos = atoi(p);
			char respuesta[500];
			sprintf(respuesta,"12/%d:%d:%d\n",turno,jugador,pos);
				   
			int socket1=DameSocketConectado(tablaP[partida].host);
			if(socket1!=-1){
				write(socket1,respuesta,strlen(respuesta));
				printf("notificación: %s enviada a socket:%d \n",respuesta,socket1);
			}
			int socket2=DameSocketConectado(tablaP[partida].jug2);
			if (socket2!=-1){
				write(socket2,respuesta,strlen(respuesta));
				printf("notificación: %s enviada a socket:%d \n",respuesta,socket2);
			}
			
			if (strcmp(tablaP[partida].jug3,"0")!=0){
				int socket3=DameSocketConectado(tablaP[partida].jug3);
				if(socket3!=-1)
				{
					write(socket3,respuesta,strlen(respuesta));
					printf("notificación: %s enviada a socket:%d \n",respuesta,socket3);
				}	
			}
			if (strcmp(tablaP[partida].jug4,"0")!=0){
				int socket4=DameSocketConectado(tablaP[partida].jug4);
				if(socket4!=-1){
					write(socket4,respuesta,strlen(respuesta));
					printf("notificación: %s enviada a socket:%d \n",respuesta,socket4);
					
				}
			}	
		}

		if (codigo!=0 && codigo != 8 && codigo != 9){
			write (sock_conn,respuesta, strlen(respuesta));
			printf("Codigo: %d , Resultado: %s\n",codigo,respuesta);
			
		}	// Y lo enviamos
		
	}
	close(sock_conn);
	pthread_exit(0);
}





int main(int argc, char *argv[]) {
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	listaC.num=0;
	
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) <0)
		printf("Error creando socket");
	
	memset(&serv_adr,0,sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9100);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) <0)
		printf("Error en el bind");
	
	if (listen(sock_listen, 2) <0)
		printf("Error en el listen");
	
	conn = mysql_init(NULL);
	if(conn==NULL)
	{
		printf("Error al crear la conexion: %u %s\n", mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect(conn,"localhost","root","mysql","juego",0,NULL,0);
	if (conn==NULL){
		printf("Error al crear la connexiÃ³n: %u %s\n",mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	pthread_t thread[100];
	pthread_mutex_init(&mutex,NULL);
	
	for(i=0;;i++)
	{
		printf("Escuchando\n");
		
		sock_conn = accept(sock_listen,NULL,NULL);
		printf("He recibido conexion\n");
		sockets[i] = sock_conn;
		pthread_create (&thread[i], NULL, AtencionClientes, &sockets[i]);
	}
			
	pthread_mutex_destroy(&mutex);
	exit(0);
}

