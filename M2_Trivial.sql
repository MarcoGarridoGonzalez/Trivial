-- MySQL dump 10.13  Distrib 5.7.33, for Linux (x86_64)
--
-- Host: localhost    Database: juego
-- ------------------------------------------------------
-- Server version	5.7.33-0ubuntu0.16.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `informacion`
--

DROP TABLE IF EXISTS `informacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `informacion` (
  `id_j` int(11) NOT NULL,
  `id_p` int(11) NOT NULL,
  `posicion` int(11) NOT NULL,
  `puntuacion` int(11) NOT NULL,
  KEY `id_j` (`id_j`),
  KEY `id_p` (`id_p`),
  CONSTRAINT `informacion_ibfk_1` FOREIGN KEY (`id_j`) REFERENCES `jugador` (`id`),
  CONSTRAINT `informacion_ibfk_2` FOREIGN KEY (`id_p`) REFERENCES `partida` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `informacion`
--

LOCK TABLES `informacion` WRITE;
/*!40000 ALTER TABLE `informacion` DISABLE KEYS */;
INSERT INTO `informacion` VALUES (4,1,1,49),(6,1,2,42),(4,2,2,40),(3,2,1,47),(4,3,2,38),(3,3,1,39);
/*!40000 ALTER TABLE `informacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jugador`
--

DROP TABLE IF EXISTS `jugador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jugador` (
  `id` int(11) NOT NULL,
  `username` varchar(15) DEFAULT NULL,
  `contraseña` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jugador`
--

LOCK TABLES `jugador` WRITE;
/*!40000 ALTER TABLE `jugador` DISABLE KEYS */;
INSERT INTO `jugador` VALUES (3,'Mario','321'),(4,'Juan','abc'),(6,'Maria','123'),(7,'Marco','abc'),(8,'Ivan','123'),(9,'Pau','so'),(10,'Matias','eetac'),(11,'Izan','eetac'),(12,'Jan','456'),(13,'Pedro','abc'),(14,'A','b'),(15,'Ziuyi Chen','chino777');
/*!40000 ALTER TABLE `jugador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partida`
--

DROP TABLE IF EXISTS `partida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partida` (
  `id` int(11) NOT NULL,
  `duracion` float DEFAULT NULL,
  `fecha` varchar(15) DEFAULT NULL,
  `hora` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partida`
--

LOCK TABLES `partida` WRITE;
/*!40000 ALTER TABLE `partida` DISABLE KEYS */;
INSERT INTO `partida` VALUES (1,2.3,'12/03/23','16:39'),(2,3.3,'23/03/23','16:30'),(3,2.5,'14/01/24','15:30');
/*!40000 ALTER TABLE `partida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preguntas`
--

DROP TABLE IF EXISTS `preguntas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `preguntas` (
  `id` int(11) NOT NULL,
  `tema` varchar(40) DEFAULT NULL,
  `pregunta` varchar(300) DEFAULT NULL,
  `respuestas` varchar(100) DEFAULT NULL,
  `correcta` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preguntas`
--

LOCK TABLES `preguntas` WRITE;
/*!40000 ALTER TABLE `preguntas` DISABLE KEYS */;
INSERT INTO `preguntas` VALUES (1,'Geografia','¿Cuál es el río más largo del mundo?','Nilo/Amazonas/Yangtsé/Misisipi','Amazonas'),(2,'Geografia','¿En qué continente se encuentra el desierto del Sahara?','Asia/América del Norte/Australia/África','África'),(3,'Geografia','¿Cuál es la capital de Japón?','Beijing/Seúl/Tokio/Bangkok','Tokio'),(4,'Geografia','¿Cuál es el país más grande del mundo por superficie?','China/Canadá/Estados Unidos/Rusia','Rusia'),(5,'Geografia','¿Cuál es el nombre del océano que está al este de África?','Océano Atlántico/Océano Pacífico/Océano Índico/Océano Ártico','Océano Índico'),(6,'Geografia','¿Cuál es el punto más alto de la Tierra?','Monte Everest/K2/Monte Kilimanjaro/Mont Blanc','Monte Everest'),(7,'Geografia','¿En qué país se encuentra la Torre Eiffel?','Italia/Alemania/España/Francia','Francia'),(8,'Geografia','¿Cuál es la capital de Australia?','Sídney/Melbourne/Canberra/Perth','Canberra'),(9,'Geografia','¿Qué país tiene la mayor cantidad de islas en el mundo?','Indonesia/Canadá/Filipinas/Suecia','Suecia'),(10,'Geografia','¿Cuál es el nombre del mar entre Europa y África?','Mar del Norte/Mar Rojo/Mar Mediterráneo/Mar Caribe','Mar Mediterráneo'),(11,'Geografia','¿Cuál es el país más pequeño del mundo por superficie?','Mónaco/Nauru/San Marino/Ciudad del Vaticano','Ciudad del Vaticano'),(12,'Geografia','¿En qué continente se encuentra el río Amazonas?','África/Asia/América del Sur/Oceanía','América del Sur'),(13,'Geografia','¿Qué país tiene la mayor cantidad de habitantes en el mundo?','Estados Unidos/India/Indonesia/China','China'),(14,'Geografia','¿Cuál es la montaña más alta de África?','Monte Kenia/Monte Elbrus/Monte Kilimanjaro/Montes Drakensberg','Monte Kilimanjaro'),(15,'Geografia','¿Cuál es la capital de Canadá?','Toronto/Vancouver/Ottawa/Montreal','Ottawa'),(16,'Arte y literatura','¿Quién pintó \"La última cena\"?','Miguel Ángel/Leonardo da Vinci/Rafael/Vincent van Gogh','Leonardo da Vinci'),(17,'Arte y literatura','¿Quién escribió \"Cien años de soledad\"?','Julio Cortázar/Mario Vargas Llosa/Gabriel García Márquez/Jorge Luis Borges','Gabriel García Márquez'),(18,'Arte y literatura','¿Cuál es el movimiento artístico al que perteneció Pablo Picasso?','Impresionismo/Cubismo/Surrealismo/Expresionismo','Cubismo'),(19,'Arte y literatura','¿Quién es el autor de \"La Odisea\"?','Hesíodo/Platón/Homero/Sófocles','Homero'),(20,'Arte y literatura','¿En qué museo se encuentra la pintura \"La Gioconda\" (Mona Lisa)?','Museo del Prado/Museo de Arte Moderno (MoMA)/Museo del Louvre/Galería Uffizi','Museo del Louvre'),(21,'Arte y literatura','¿Quién escribió \"Don Quijote de la Mancha\"?','Lope de Vega/Francisco de Quevedo/Miguel de Cervantes/Tirso de Molina','Miguel de Cervantes'),(22,'Arte y literatura','¿Cuál de las siguientes obras fue escrita por William Shakespeare?','La metamorfosis/Hamlet/Crimen y castigo/En busca del tiempo perdido','Hamlet'),(23,'Arte y literatura','¿Qué pintor es conocido por su obra \"El grito\"?','Edvard Munch/Claude Monet/Paul Cézanne/Gustav Klimt','Edvard Munch'),(24,'Arte y literatura','¿Quién es el autor de la novela \"Matar a un ruiseñor\"?','J.D. Salinger/Harper Lee/F. Scott Fitzgerald/Ernest Hemingway','Harper Lee'),(25,'Arte y literatura','¿En qué año se publicó \"1984\" de George Orwell?','1929/1949/1954/1961','1949'),(26,'Arte y literatura','¿Quién pintó \"La noche estrellada\"?','Claude Monet/Paul Gauguin/Vincent van Gogh/Édouard Manet','Vincent van Gogh'),(27,'Arte y literatura','¿Quién escribió \"Orgullo y prejuicio\"?','Charlotte Brontë/Jane Austen/Mary Shelley/Emily Brontë','Jane Austen'),(28,'Arte y literatura','¿Cuál es la nacionalidad del escritor Haruki Murakami?','China/Corea del Sur/Japón/Tailandia','Japón'),(29,'Arte y literatura','¿Quién es el autor de \"La divina comedia\"?','Giovanni Boccaccio/Dante Alighieri/Francesco Petrarca/Torquato Tasso','Dante Alighieri'),(30,'Arte y literatura','¿Qué pintor es conocido por la serie de cuadros \"Los nenúfares\"?','Pierre-Auguste Renoir/Edgar Degas/Claude Monet/Camille Pissarro','Claude Monet'),(31,'Historia','¿En qué año comenzó la Segunda Guerra Mundial?','1935/1939/1941/1945','1939'),(32,'Historia','¿Quién fue el primer presidente de los Estados Unidos?','Thomas Jefferson/John Adams/George Washington/Abraham Lincoln','George Washington'),(33,'Historia','¿Qué civilización antigua construyó las pirámides de Giza?','Mesopotámica/Maya/Griega/Egipcia','Egipcia'),(34,'Historia','¿Qué imperio fue gobernado por Alejandro Magno?','Imperio Romano/Imperio Persa/Imperio Bizantino/Imperio Macedonio','Imperio Macedonio'),(35,'Historia','¿En qué año se firmó la Declaración de Independencia de los Estados Unidos?','1775/1776/1777/1778','1776'),(36,'Historia','¿Quién fue el líder del movimiento de independencia de la India?','Jawaharlal Nehru/Subhas Chandra Bose/Bhagat Singh/Mahatma Gandhi','Mahatma Gandhi'),(37,'Historia','¿Cuál fue el principal conflicto bélico del siglo XIX entre el norte y el sur de los Estados Unidos?','La Guerra de Independencia/La Guerra de 1812/La Guerra Civil Americana/La Guerra Mexicano-Americana','La Guerra Civil Americana'),(38,'Historia','¿Quién fue el dictador de la Alemania nazi durante la Segunda Guerra Mundial?','Benito Mussolini/Joseph Stalin/Adolf Hitler/Francisco Franco','Adolf Hitler'),(40,'Historia','¿En qué año llegó Cristóbal Colón a América?','1491/1492/1493/1494','1492'),(41,'Historia','¿Quién fue el primer emperador de Roma?','Julio César/Nerón/Calígula/Augusto','Augusto'),(43,'Historia','¿En qué año se cayó el Muro de Berlín?','1987/1988/1989/1990','1989'),(44,'Historia','¿Qué país fue liderado por el zar Pedro el Grande?','Suecia/Polonia/Rusia/Prusia','Rusia'),(45,'Historia','¿Qué famoso líder militar y emperador francés fue derrotado en la Batalla de Waterloo?','Luis XIV/Napoleón Bonaparte/Carlos Martel/Francisco I','Napoleón Bonaparte'),(46,'Entretenimiento','¿Quién es el creador de la serie de televisión \"Breaking Bad\"?','David Chase/Vince Gilligan/Matthew Weiner/J.J. Abrams','Vince Gilligan'),(47,'Entretenimiento','¿Cuál es el nombre de la princesa protagonista en la película \"La Bella y la Bestia\" de Disney?','Ariel/Bella/Cenicienta/Aurora','Bella'),(48,'Entretenimiento','¿Qué banda británica lanzó el álbum \"Abbey Road\"?','The Rolling Stones/The Beatles/The Who/Led Zeppelin','The Beatles'),(49,'Entretenimiento','¿En qué año se estrenó la primera película de \"Harry Potter\"?','1999/2000/2001/2002','2001'),(50,'Entretenimiento','¿Quién ganó el Oscar a Mejor Actor en la ceremonia de 2020 por su papel en \"Joker\"?','Leonardo DiCaprio/Brad Pitt/Joaquin Phoenix/Tom Hanks','Joaquin Phoenix'),(51,'Entretenimiento','Cuál es el nombre real del superhéroe Iron Man en los cómics de Marvel?','Bruce Wayne/Steve Rogers/Tony Stark/Clark Kent','Tony Stark'),(52,'Entretenimiento','¿Quién es el autor de la serie de libros \"Canción de Hielo y Fuego\", que inspiró la serie \"Juego de Tronos\"?','J.R.R. Tolkien/George R.R. Martin/J.K. Rowling/Suzanne Collins','George R.R. Martin'),(53,'Entretenimiento','¿Qué película ganó el Oscar a Mejor Película en la ceremonia de 2019?','Green Book/Roma/Black Panther/Bohemian Rhapsody','Green Book'),(54,'Entretenimiento','¿Quién interpretó a Jack Dawson en la película \"Titanic\"?','Brad Pitt/Leonardo DiCaprio/Tom Cruise/Johnny Depp','Leonardo DiCaprio'),(55,'Entretenimiento','¿Cuál es el nombre del parque temático de Disney en París?','Disneyland Tokyo/Disneyland Paris/Disney World/DisneySea','Disneyland Paris'),(56,'Entretenimiento','¿Quién interpretó a Batman en la trilogía dirigida por Christopher Nolan?','Christian Bale/Michael Keaton/Ben Affleck/George Clooney','Christian Bale'),(57,'Entretenimiento','¿Cuál es el nombre del actor que protagonizó la serie de televisión \"Breaking Bad\"?','Bryan Cranston/Aaron Paul/Dean Norris/Bob Odenkirk','Bryan Cranston'),(58,'Entretenimiento','¿Qué película dirigida por Quentin Tarantino ganó el Oscar a Mejor Película en 1995?','Reservoir Dogs/Pulp Fiction/Kill Bill: Volumen 1/Django sin cadenas','Pulp Fiction'),(59,'Entretenimiento','¿Cuál es el nombre del personaje principal en la serie de televisión \"The Walking Dead\"?','Rick Grimes/Daryl Dixon/Glenn Rhee/Michonne','Rick Grimes'),(60,'Entretenimiento','¿Qué película de Pixar presenta a un pez payaso llamado Nemo?','Buscando a Nemo/Up/Toy Story/Ratatouille','Buscando a Nemo'),(61,'Ciencias y naturaleza','¿Cuál es el planeta más grande del sistema solar?','Venus/Júpiter/Marte/Saturno','Júpiter'),(62,'Ciencias y naturaleza','¿Cuál es el hueso más largo del cuerpo humano?','Fémur/Radio/Tibia/Húmero','Fémur'),(63,'Ciencias y naturaleza','¿Cuál es el proceso por el cual las plantas convierten la luz solar en energía química?','Fotosíntesis/Respiración/Fermentación/Transpiración','Fotosíntesis'),(64,'Ciencias y naturaleza','¿Cuál es la capa más externa de la Tierra?','Núcleo/Manto/Corteza/Núcleo externo','Corteza'),(65,'Ciencias y naturaleza','¿Qué órgano del cuerpo humano es responsable de bombear sangre a través del sistema circulatorio?','Riñón/Pulmón/Corazón/Hígado','Corazón'),(66,'Ciencias y naturaleza','¿Cuál es el proceso por el cual el agua se convierte en vapor de agua en la atmósfera?','Condensación/Sublimación/Evaporación/Precipitación','Evaporación'),(67,'Ciencias y naturaleza','¿Cuál es la hormona responsable de regular los niveles de glucosa en sangre en el cuerpo humano?','Insulina/Cortisol/Adrenalina/Testosterona','Insulina'),(68,'Ciencias y naturaleza','¿Cuál es el proceso por el cual los seres vivos obtienen energía de los alimentos?','Fotosíntesis/Respiración/Digestión/Metabolismo','Respiración'),(69,'Ciencias y naturaleza','¿Cuál es el animal más grande del mundo?','Elefante africano/Ballena azul/Oso polar/Jirafa','Ballena azul'),(70,'Ciencias y naturaleza','¿Cuál es el proceso por el cual las plantas absorben agua y nutrientes del suelo a través de sus raíces?','Fotosíntesis/Transpiración/Absorción/Capilaridad','Absorción'),(71,'Ciencias y naturaleza','¿Cuál es el ácido presente en los cítricos como limones y naranjas?','Ácido sulfúrico/Ácido acético/Ácido cítrico/Ácido clorhídrico','Ácido cítrico'),(72,'Ciencias y naturaleza','¿Cuál es la capa atmosférica donde se produce la mayoría de los fenómenos meteorológicos?','Estratosfera/Troposfera/Mesosfera/Exosfera','Troposfera'),(73,'Ciencias y naturaleza','¿Cuál es el proceso natural por el cual el agua líquida se convierte en vapor de agua?','Evaporación/Fusión/Sublimación/Condensación','Evaporación'),(74,'Ciencias y naturaleza','¿Cuál es el animal más veloz del mundo en vuelo picado?','Águila/Halcón peregrino/Guepardo/León','Halcón peregrino'),(75,'Ciencias y naturaleza','¿Cuál es la sustancia química que las plantas usan para llevar a cabo la fotosíntesis?','Clorofila/Hemoglobina/Melanina/Queratina','Clorofila'),(76,'Deportes','¿Cuál es el deporte más popular en todo el mundo?','Fútbol (soccer)/Baloncesto/Béisbol/Tenis','Fútbol (soccer)'),(77,'Deportes','¿Cuál de los siguientes deportes se juega en una pista ovalada y los competidores utilizan patines?','Baloncesto/Béisbol/Hockey sobre hielo/Ciclismo de pista','Hockey sobre hielo'),(78,'Deportes','¿Cuál es el evento más importante en el mundo del tenis, jugado en Londres cada año?','Abierto de Estados Unidos/Wimbledon/Abierto de Australia/Roland Garros','Wimbledon'),(79,'Deportes','¿En qué deporte se otorga una \"medalla de oro\" al ganador?','Fútbol/Baloncesto/Natación/Atletismo','Atletismo'),(80,'Deportes','¿Cuál es el equipo más exitoso en la historia de la Liga de Campeones de la UEFA (Champions League)?','FC Barcelona/Real Madrid/Manchester United/Bayern de Múnich','Real Madrid'),(81,'Deportes','¿Cuál es el deporte que se juega con una pelota pequeña en una mesa dividida por una red?','Tenis/Bádminton/Ping pong (tenis de mesa)/Squash','Ping pong (tenis de mesa)'),(82,'Deportes','¿Qué equipo ha ganado más títulos de la NBA en la historia?','Los Angeles Lakers/Chicago Bulls/Boston Celtics/Golden State Warriors','Chicago Bulls'),(83,'Deportes','¿Cuál es el récord mundial del hombre más rápido en los 100 metros lisos?','9,58 segundos/9,69 segundos/9,72 segundos/9,81 segundos','9,81 segundos'),(84,'Deportes','¿Cuál de los siguientes deportes utiliza una raqueta para golpear una pelota contra una pared frontal?','Golf/Squash/Rugby/Surf','Squash'),(85,'Deportes','¿En qué deporte se puntúa al anotar un \"touchdown\"?','Fútbol americano/Béisbol/Baloncesto/Fútbol (soccer)','Fútbol americano'),(86,'Deportes','¿Qué país ha ganado más medallas de oro en la historia de los Juegos Olímpicos de Verano?','Estados Unidos/China/Rusia/Alemania','Estados Unidos'),(87,'Deportes','¿En qué deporte se compite por el título del \"Maillot Jaune\" (Jersey Amarillo)?','Ciclismo/Natación/Atletismo/Esquí alpino','Ciclismo'),(88,'Deportes','¿Cuál es el deporte más popular en la India?','Cricket/Hockey sobre césped/Fútbol/Tenis','Cricket'),(89,'Deportes','¿Qué equipo ganó la última Copa Mundial de Fútbol Femenino en 2019?','Alemania/Brasil/Estados Unidos/Francia','Estados Unidos'),(90,'Deportes','¿Cuál es el torneo de tenis más antiguo del mundo, jugado en césped desde 1877?','Abierto de Australia/Roland Garros/Wimbledon/Abierto de Estados Unidos','Roland Garros');
/*!40000 ALTER TABLE `preguntas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ranking`
--

DROP TABLE IF EXISTS `ranking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ranking` (
  `id_j` int(11) NOT NULL,
  `puntos` int(11) NOT NULL,
  `username` varchar(15) DEFAULT NULL,
  KEY `id_j` (`id_j`),
  CONSTRAINT `ranking_ibfk_1` FOREIGN KEY (`id_j`) REFERENCES `jugador` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ranking`
--

LOCK TABLES `ranking` WRITE;
/*!40000 ALTER TABLE `ranking` DISABLE KEYS */;
INSERT INTO `ranking` VALUES (4,49,'Juan'),(3,47,'Mario');
/*!40000 ALTER TABLE `ranking` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-26  0:09:22
