SET NAMES utf8 ;

DROP TABLE IF EXISTS `Room`;
SET character_set_client = utf8mb4 ;
CREATE TABLE `Room` (
  `customerID` varchar(10) NOT NULL,
  `roomNumber` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customerID`),
  CONSTRAINT `customerID` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Room` WRITE;
UNLOCK TABLES;