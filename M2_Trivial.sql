DROP DATABASE IF EXISTS M2_Trivial;
CREATE DATABASE M2_Trivial;

USE M2_Trivial;

CREATE TABLE jugador (
	id INTEGER NOT NULL PRIMARY KEY,
	username VARCHAR(15),
	contraseña VARCHAR(15)
);

CREATE TABLE partida (
	id INTEGER NOT NULL PRIMARY KEY,
	duracion FLOAT,
	fecha VARCHAR(15),
	hora VARCHAR(15)
);

CREATE TABLE informacion(
	id_j INTEGER NOT NULL,
	id_p integer not null,
	id_posicion INTEGER NOT NULL,
	puntuacion INTEGER NOT NULL,
	FOREIGN KEY (id_j) REFERENCES jugador (id),
	FOREIGN KEY (id_p) REFERENCES partida (id)
);




INSERT INTO jugador VALUES (4,'Juan', 'abc');
INSERT INTO jugador VALUES (6,'Maria', '123');
INSERT INTO jugador VALUES (3,'Mario','321');

INSERT INTO partida VALUES (1,2.30,'12/03/23','16:39');
INSERT INTO partida VALUES (2,3.30,'23/03/23','16:30');

INSERT INTO informacion VALUES (4,1,1,49);
INSERT INTO informacion VALUES (3,1,2,42);
INSERT INTO informacion VALUES (3,2,1,47);
INSERT INTO informacion VALUES (4,2,2,41);
