SET NAMES utf8 ;

DROP TABLE IF EXISTS `Customer`;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Customer` (
  `customerID` varchar(10) NOT NULL,
  `customerName` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Customer` WRITE;
UNLOCK TABLES;