SET NAMES utf8 ;

DROP TABLE IF EXISTS `Invoice`;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Invoice` (
  `customerID` varchar(12) NOT NULL,
  `days` int(11) DEFAULT NULL,
  `roomNumber` varchar(45) DEFAULT NULL,
  `verified` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`customerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Invoice` WRITE;
UNLOCK TABLES;