CREATE DATABASE  IF NOT EXISTS `rekenenracer` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `rekenenracer`;
-- MariaDB dump 10.17  Distrib 10.4.14-MariaDB, for Win64 (AMD64)
--
-- Host: 127.0.0.1    Database: rekenenwoordenracer
-- ------------------------------------------------------
-- Server version	10.4.14-MariaDB

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
-- Table structure for table `gebruikers`
--

DROP TABLE IF EXISTS `gebruikers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gebruikers` (
  `gebruikerId` int(11) NOT NULL AUTO_INCREMENT,
  `gebruikersnaam` varchar(255) NOT NULL,
  `wachtwoord` varchar(255) NOT NULL,
  PRIMARY KEY (`gebruikerId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `highscores`
--

DROP TABLE IF EXISTS `highscores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `highscores` (
  `idhighscores` int(11) NOT NULL AUTO_INCREMENT,
  `score` int(11) NOT NULL,
  `gebruikerId` int(11) NOT NULL,
  `datum` date NOT NULL,
  `tijd` time NOT NULL,
  PRIMARY KEY (`idhighscores`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `reken_antwoorden`
--

DROP TABLE IF EXISTS `reken_antwoorden`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reken_antwoorden` (
  `antwoordId` int(11) NOT NULL AUTO_INCREMENT,
  `antwoord` varchar(45) DEFAULT NULL,
  `vraagId` int(11) NOT NULL,
  PRIMARY KEY (`antwoordId`),
  KEY `vraagId_idx` (`vraagId`),
  CONSTRAINT `vraagId` FOREIGN KEY (`vraagId`) REFERENCES `reken_vragen` (`vraagId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reken_antwoorden`
--

LOCK TABLES `reken_antwoorden` WRITE;
/*!40000 ALTER TABLE `reken_antwoorden` DISABLE KEYS */;
INSERT INTO `reken_antwoorden` VALUES (2,'56',1),(3,'27',2),(4,'36',3),(5,'37',4),(6,'101',5),(7,'52',6),(8,'36',7),(9,'39',8),(10,'49',9),(11,'24',10);
/*!40000 ALTER TABLE `reken_antwoorden` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reken_vragen`
--

DROP TABLE IF EXISTS `reken_vragen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reken_vragen` (
  `vraagId` int(11) NOT NULL AUTO_INCREMENT,
  `vraag` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`vraagId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reken_vragen`
--

LOCK TABLES `reken_vragen` WRITE;
/*!40000 ALTER TABLE `reken_vragen` DISABLE KEYS */;
INSERT INTO `reken_vragen` VALUES (1,'7 * 8'),(2,'55 - 28'),(3,' 9 * 4'),(4,'66 - 39'),(5,'34 + 67'),(6,'27 + 25'),(7,'6 * 6'),(8,'68 - 29'),(9,'92 - 43'),(10,'8 * 3');
/*!40000 ALTER TABLE `reken_vragen` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-10-24 19:03:32
