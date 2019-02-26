SET NAMES utf8 ;

DROP TABLE IF EXISTS `Transaction`;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Transaction` (
  `customerID` varchar(10) NOT NULL,
  `amount` int(11) DEFAULT NULL,
  `method` varchar(20) DEFAULT NULL,
  `status` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`customerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Transaction` WRITE;

UNLOCK TABLES;