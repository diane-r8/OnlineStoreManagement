-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: onlinestore
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` text DEFAULT NULL,
  PRIMARY KEY (`customer_id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'John','Doe','john@example.com','09123456789','123 Main St, Manila'),(2,'Jane','Smith','jane@example.com','09281234567','456 Elm St, Quezon City'),(3,'Alice','Brown','alice@example.com','09111222333','789 Pine St, Cebu'),(4,'Bob','Johnson','bob@example.com','09491234567','101 Oak St, Davao'),(5,'Charlie','Williams','charlie@example.com','09591234567','202 Birch St, Baguio'),(6,'David','Miller','david@example.com','09691234567','303 Maple St, Iloilo'),(7,'Ella','Davis','ella@example.com','09791234567','404 Cedar St, Batangas'),(8,'Frank','Wilson','frank@example.com','09891234567','505 Spruce St, Pampanga'),(9,'Grace','Lee','grace@example.com','09991234567','606 Fir St, Cavite'),(10,'Hannah','Taylor','hannah@example.com','09091234567','707 Ash St, Laguna'),(11,'Princess Diane','Rosana','yandydiane08@gmail.com','09706104541','P6 Sto. Domingo, Albay');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderitems`
--

DROP TABLE IF EXISTS `orderitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderitems` (
  `order_item_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`order_item_id`),
  KEY `order_id` (`order_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `orderitems_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `orderitems_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitems`
--

LOCK TABLES `orderitems` WRITE;
/*!40000 ALTER TABLE `orderitems` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `total_amount` decimal(10,2) NOT NULL,
  `status` enum('Pending','Shipped','Delivered','Cancelled') NOT NULL DEFAULT 'Pending',
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`order_id`),
  KEY `customer_id` (`customer_id`),
  KEY `fk_product` (`product_id`),
  CONSTRAINT `fk_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,3,'2024-01-10 01:15:00',45000.00,'Shipped',1,1),(2,7,'2024-02-05 06:30:00',998.00,'Shipped',2,2),(3,2,'2024-03-12 03:45:00',4500.00,'Delivered',3,3),(4,10,'2024-04-18 08:00:00',299.00,'Pending',4,1),(5,5,'2024-05-23 02:20:00',3196.00,'Delivered',5,4),(6,1,'2024-06-15 05:10:00',700.00,'Delivered',6,2),(7,8,'2024-07-09 07:25:00',899.00,'Pending',7,1),(8,4,'2024-08-14 09:40:00',15000.00,'Delivered',8,3),(9,6,'2024-09-20 04:55:00',25000.00,'Shipped',9,1),(10,11,'2024-10-25 01:05:00',1200.00,'Cancelled',10,2),(11,9,'2024-11-30 06:15:00',1200.00,'Delivered',11,1),(12,2,'2024-12-05 03:30:00',3999.95,'Shipped',12,5),(13,5,'2025-01-10 08:45:00',300.00,'Cancelled',13,2),(14,7,'2025-02-14 02:00:00',45000.00,'Delivered',1,1),(15,3,'2025-03-19 05:20:00',1497.00,'Shipped',2,3),(16,10,'2025-04-23 07:35:00',3000.00,'Cancelled',3,2),(17,1,'2024-01-15 01:50:00',1196.00,'Delivered',4,4),(18,8,'2024-02-20 06:10:00',799.00,'Shipped',5,1),(19,6,'2024-03-25 03:25:00',700.00,'Cancelled',6,2),(20,9,'2024-04-30 08:40:00',899.00,'Delivered',7,1),(21,11,'2024-05-05 02:55:00',10000.00,'Shipped',8,2),(22,4,'2024-06-10 05:05:00',25000.00,'Cancelled',9,1),(23,2,'2024-07-15 07:20:00',1800.00,'Delivered',10,3),(24,5,'2024-08-20 09:35:00',2400.00,'Shipped',11,2),(25,7,'2024-09-25 04:50:00',799.99,'Pending',12,1),(26,3,'2024-10-30 01:00:00',600.00,'Delivered',13,4),(27,10,'2024-11-04 06:10:00',45000.00,'Shipped',1,1),(28,1,'2024-12-09 03:25:00',998.00,'Cancelled',2,2),(29,8,'2025-01-14 08:40:00',1500.00,'Delivered',3,1),(30,6,'2025-05-19 02:55:00',897.00,'Shipped',4,3),(31,11,'2025-05-19 02:42:54',120.00,'Pending',19,2),(32,11,'2025-05-19 02:56:00',76.00,'Pending',17,2),(33,11,'2025-05-11 03:09:13',150.00,'Pending',13,1);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER after_order_insert
AFTER INSERT ON orders
FOR EACH ROW
BEGIN
    UPDATE products
    SET stock_quantity = stock_quantity - NEW.quantity
    WHERE product_id = NEW.product_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `payment_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `amount` decimal(10,2) NOT NULL,
  `payment_method` enum('Credit Card','GCash','Bank Transfer','COD') NOT NULL,
  `status` enum('Pending','Completed','Failed','Refunded') NOT NULL DEFAULT 'Pending',
  PRIMARY KEY (`payment_id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,1,'2025-05-18 03:39:12',1234.00,'COD','Completed'),(2,2,'2024-02-06 03:15:00',998.00,'Credit Card','Pending'),(3,3,'2024-03-13 01:30:00',4500.00,'Bank Transfer','Completed'),(4,4,'2024-04-19 06:45:00',299.00,'COD','Refunded'),(5,5,'2024-05-24 08:20:00',3196.00,'GCash','Completed'),(6,6,'2024-06-16 05:10:00',700.00,'Credit Card','Pending'),(7,7,'2024-07-10 07:25:00',899.00,'Bank Transfer','Completed'),(8,8,'2024-08-15 09:40:00',15000.00,'COD','Pending'),(9,9,'2024-09-21 04:55:00',25000.00,'GCash','Completed'),(10,10,'2024-10-26 01:05:00',1200.00,'Bank Transfer','Pending'),(11,11,'2024-12-01 06:15:00',1200.00,'Bank Transfer','Completed'),(12,12,'2024-12-06 03:30:00',3999.95,'COD','Pending'),(13,13,'2025-01-11 08:45:00',300.00,'GCash','Completed'),(14,14,'2025-02-15 02:00:00',45000.00,'Credit Card','Pending'),(15,15,'2025-03-20 05:20:00',1497.00,'Bank Transfer','Completed'),(16,16,'2025-04-24 07:35:00',3000.00,'COD','Pending'),(17,17,'2024-01-16 01:50:00',1196.00,'GCash','Completed'),(18,18,'2024-02-21 06:10:00',799.00,'Credit Card','Pending'),(19,19,'2024-03-26 03:25:00',700.00,'Bank Transfer','Completed'),(20,20,'2024-05-01 08:40:00',899.00,'COD','Pending'),(21,21,'2024-05-06 02:55:00',10000.00,'GCash','Completed'),(22,22,'2024-06-11 05:05:00',25000.00,'Credit Card','Pending'),(23,23,'2024-07-16 07:20:00',1800.00,'Bank Transfer','Completed'),(24,24,'2024-08-21 09:35:00',2400.00,'COD','Pending'),(25,25,'2024-09-26 04:50:00',799.99,'GCash','Completed'),(26,26,'2024-10-31 01:00:00',600.00,'Credit Card','Pending'),(27,27,'2024-11-05 06:10:00',45000.00,'Bank Transfer','Completed'),(28,28,'2024-12-10 03:25:00',998.00,'COD','Pending'),(29,29,'2025-01-15 08:40:00',1500.00,'GCash','Completed'),(30,30,'2025-05-20 02:55:00',897.00,'Credit Card','Pending'),(32,1,'2025-05-18 03:39:12',1234.00,'COD','Completed'),(33,7,'2025-05-18 03:43:18',9876.00,'Credit Card','Refunded');
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productcategories`
--

DROP TABLE IF EXISTS `productcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productcategories` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productcategories`
--

LOCK TABLES `productcategories` WRITE;
/*!40000 ALTER TABLE `productcategories` DISABLE KEYS */;
INSERT INTO `productcategories` VALUES (1,'Electronics','Devices, gadgets, and electronic accessories.'),(2,'Clothing','Apparel, shoes, and fashion accessories.'),(3,'Home & Kitchen','Home appliances, kitchenware, and furniture.'),(4,'Health & Beauty','Personal care, wellness, and beauty products.'),(5,'Sports','Sports equipment, activewear, and outdoor gear.'),(6,'Toys & Games','Toys, games, and children’s entertainment.'),(7,'Books','Books, magazines, and educational materials.'),(8,'Automotive','Automotive parts, tools, and car accessories.'),(9,'Jewelry','Jewelry, watches, and luxury accessories.'),(10,'Groceries','Groceries, food, and beverages.');
/*!40000 ALTER TABLE `productcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `product_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_name` varchar(100) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) NOT NULL,
  `description` text DEFAULT NULL,
  PRIMARY KEY (`product_id`),
  KEY `category_id` (`category_id`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `productcategories` (`category_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Laptop',1,45000.00,10,'A high-performance laptop suitable for work and gaming.'),(2,'T-shirt',2,499.00,50,'Comfortable cotton T-shirt available in various sizes.'),(3,'Blender',1,1500.00,20,'Multi-speed kitchen blender for smoothies and more.'),(4,'Shampoo',4,299.00,100,'Gentle and effective shampoo for daily hair care.'),(5,'Basketball',5,799.00,30,'Durable basketball for indoor and outdoor play.'),(6,'Toy Car',6,350.00,40,'Fun toy car for children aged 3 and above.'),(7,'Novel Book',7,899.00,60,'Bestselling novel book for avid readers.'),(8,'Car Tire',8,5000.00,15,'Heavy-duty car tire for all weather conditions.'),(9,'Gold Necklace',9,25000.00,5,'Elegant gold necklace, perfect for special occasions.'),(10,'Rice (10kg)',10,600.00,200,'Premium quality rice, 10kg pack.'),(11,'Wireless Mouse',1,1200.00,50,'Wireless mouse with ergonomic design.'),(12,'Wireless Keyboard',1,799.99,40,'Wireless keyboard with long battery life.'),(13,'Uno Cards',6,150.00,64,'Card game for small or big groups of people.'),(15,'Soap',4,45.00,55,'Body soap for adults.'),(16,'Silver Earrings',9,2500.00,45,'Shining, shimmering, silver earrings.'),(17,'Noodles',10,38.00,28,'Flavorful cup noodles, just add hot water.'),(19,'Biscuits',10,60.00,50,'Chocolate biscuits with chocolate fillings.'),(20,'Story Book',7,35.00,29,'Bedtime stories for kids.');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviews`
--

DROP TABLE IF EXISTS `reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviews` (
  `review_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `rating` int(11) DEFAULT NULL CHECK (`rating` between 1 and 5),
  `review_text` text DEFAULT NULL,
  `review_date` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`review_id`),
  KEY `customer_id` (`customer_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `reviews_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reviews_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` VALUES (1,1,1,5,'Great laptop! Super fast and reliable.','2024-02-01 02:30:00'),(2,2,2,4,'Nice t-shirt, but the size runs a bit small.','2024-02-02 04:15:00'),(3,3,3,5,'Love this blender! Makes smoothies perfectly.','2024-02-03 01:45:00'),(4,4,4,3,'Shampoo is okay, but the scent is too strong.','2024-02-04 06:20:00'),(5,5,5,5,'Best basketball ever! Great grip and bounce.','2024-02-05 08:05:00'),(6,6,6,4,'My kid loves this toy car! Very durable.','2024-02-06 10:30:00'),(7,7,7,5,'Such a great novel, couldn\'t put it down!','2024-02-07 12:10:00'),(8,8,8,2,'Tires are okay, but the delivery was slow.','2024-02-08 14:45:00'),(9,9,9,5,'Absolutely stunning necklace! Worth every penny.','2024-02-09 00:00:00'),(10,10,10,4,'Good quality rice, but packaging could be better.','2024-02-10 03:55:00');
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(50) NOT NULL,
  PRIMARY KEY (`role_id`),
  UNIQUE KEY `role_name` (`role_name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrator'),(2,'Staff');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(100) NOT NULL,
  `role_id` int(11) NOT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin123','admin@gmail.com',1,'2025-05-17 18:22:48','2025-05-17 18:28:50'),(2,'staff','staff123','staff@gmail.com',2,'2025-05-17 18:23:48','2025-05-17 18:23:48');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_customerorders`
--

DROP TABLE IF EXISTS `view_customerorders`;
/*!50001 DROP VIEW IF EXISTS `view_customerorders`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_customerorders` AS SELECT 
 1 AS `customer_id`,
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `total_orders`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_customers`
--

DROP TABLE IF EXISTS `view_customers`;
/*!50001 DROP VIEW IF EXISTS `view_customers`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_customers` AS SELECT 
 1 AS `customer_id`,
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `email`,
 1 AS `phone`,
 1 AS `address`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_orderpayments`
--

DROP TABLE IF EXISTS `view_orderpayments`;
/*!50001 DROP VIEW IF EXISTS `view_orderpayments`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_orderpayments` AS SELECT 
 1 AS `order_id`,
 1 AS `TotalPaid`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_orders`
--

DROP TABLE IF EXISTS `view_orders`;
/*!50001 DROP VIEW IF EXISTS `view_orders`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_orders` AS SELECT 
 1 AS `order_id`,
 1 AS `customer_id`,
 1 AS `total_amount`,
 1 AS `status`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_ordersummary`
--

DROP TABLE IF EXISTS `view_ordersummary`;
/*!50001 DROP VIEW IF EXISTS `view_ordersummary`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_ordersummary` AS SELECT 
 1 AS `order_id`,
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `total_amount`,
 1 AS `status`,
 1 AS `payment_status`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_topproducts`
--

DROP TABLE IF EXISTS `view_topproducts`;
/*!50001 DROP VIEW IF EXISTS `view_topproducts`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_topproducts` AS SELECT 
 1 AS `product_id`,
 1 AS `product_name`,
 1 AS `total_sold`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'onlinestore'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS `auto_cancel_old_orders` */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8mb4 */ ;;
/*!50003 SET character_set_results = utf8mb4 */ ;;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `auto_cancel_old_orders` ON SCHEDULE EVERY 1 DAY STARTS '2025-05-19 11:03:33' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE orders
    SET status = 'Cancelled'
    WHERE status = 'Pending'
      AND order_date < DATE_SUB(NOW(), INTERVAL 7 DAY) */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;

--
-- Dumping routines for database 'onlinestore'
--
/*!50003 DROP FUNCTION IF EXISTS `GetCustomerFullName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetCustomerFullName`(custId INT) RETURNS varchar(100) CHARSET utf8mb4 COLLATE utf8mb4_general_ci
    DETERMINISTIC
BEGIN
    DECLARE full_name VARCHAR(100);
    SELECT CONCAT(first_name, ' ', last_name) INTO full_name FROM Customers WHERE customer_id = custId;
    RETURN full_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetDiscount` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetDiscount`(orderTotal DECIMAL(10,2)) RETURNS decimal(10,2)
    DETERMINISTIC
BEGIN
    DECLARE discount DECIMAL(10,2);
    IF orderTotal >= 5000 THEN
        SET discount = orderTotal * 0.10;  -- 10% discount
    ELSEIF orderTotal >= 2000 THEN
        SET discount = orderTotal * 0.05;  -- 5% discount
    ELSE
        SET discount = 0;
    END IF;
    RETURN discount;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetOrderStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetOrderStatus`(orderId INT) RETURNS char(10) CHARSET utf8mb4 COLLATE utf8mb4_general_ci
    DETERMINISTIC
BEGIN
    DECLARE order_status CHAR(10);
    SELECT status INTO order_status FROM Orders WHERE order_id = orderId;
    RETURN order_status;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetTotalPaid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetTotalPaid`(orderId INT) RETURNS decimal(10,2)
    DETERMINISTIC
BEGIN
    DECLARE total_paid DECIMAL(10,2);
    SELECT SUM(amount) INTO total_paid FROM Payments WHERE order_id = orderId;
    RETURN IFNULL(total_paid, 0);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetTotalStock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetTotalStock`() RETURNS int(11)
    DETERMINISTIC
BEGIN
    DECLARE total_stock INT;
    SELECT SUM(stock_quantity) INTO total_stock FROM Products;
    RETURN total_stock;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddProduct` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddProduct`(
    IN prod_name VARCHAR(100), 
    IN cat_id INT, 
    IN price DECIMAL(10,2), 
    IN stock INT
)
BEGIN
    INSERT INTO Products (product_name, category_id, price, stock_quantity)
    VALUES (prod_name, cat_id, price, stock);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CalculateTotalSales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CalculateTotalSales`()
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE p_id INT;
    DECLARE p_name VARCHAR(100);
    DECLARE total_sales DECIMAL(10,2);
    DECLARE sales_cursor CURSOR FOR 
        SELECT p.product_id, p.product_name, SUM(oi.quantity * oi.price) AS total_sales
        FROM Products p
        JOIN OrderItems oi ON p.product_id = oi.product_id
        GROUP BY p.product_id;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    OPEN sales_cursor;

    read_loop: LOOP
        FETCH sales_cursor INTO p_id, p_name, total_sales;
        IF done THEN 
            LEAVE read_loop;
        END IF;
        SELECT p_id AS ProductID, p_name AS ProductName, total_sales AS TotalSales;
    END LOOP;

    CLOSE sales_cursor;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ListCustomerOrders` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ListCustomerOrders`(IN custId INT)
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE o_id INT;
    DECLARE o_date TIMESTAMP;
    DECLARE total DECIMAL(10,2);
    DECLARE order_cursor CURSOR FOR 
        SELECT order_id, order_date, total_amount FROM Orders WHERE customer_id = custId;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    OPEN order_cursor;

    read_loop: LOOP
        FETCH order_cursor INTO o_id, o_date, total;
        IF done THEN 
            LEAVE read_loop;
        END IF;
        SELECT o_id AS OrderID, o_date AS OrderDate, total AS TotalAmount;
    END LOOP;

    CLOSE order_cursor;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ShowOrderSummary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ShowOrderSummary`(IN custId INT)
BEGIN
    SELECT o.order_id, 
           GetCustomerFullName(custId) AS CustomerName, 
           o.total_amount, 
           GetDiscount(o.total_amount) AS Discount, 
           GetTotalPaid(o.order_id) AS TotalPaid,
           o.status
    FROM Orders o
    WHERE o.customer_id = custId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateOrderStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateOrderStatus`(IN orderId INT, IN newStatus ENUM('Pending', 'Shipped', 'Delivered', 'Cancelled'))
BEGIN
    UPDATE Orders SET status = newStatus WHERE order_id = orderId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `view_customerorders`
--

/*!50001 DROP VIEW IF EXISTS `view_customerorders`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_customerorders` AS select `c`.`customer_id` AS `customer_id`,`c`.`first_name` AS `first_name`,`c`.`last_name` AS `last_name`,count(`o`.`order_id`) AS `total_orders` from (`customers` `c` left join `orders` `o` on(`c`.`customer_id` = `o`.`customer_id`)) group by `c`.`customer_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_customers`
--

/*!50001 DROP VIEW IF EXISTS `view_customers`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_customers` AS select `customers`.`customer_id` AS `customer_id`,`customers`.`first_name` AS `first_name`,`customers`.`last_name` AS `last_name`,`customers`.`email` AS `email`,`customers`.`phone` AS `phone`,`customers`.`address` AS `address` from `customers` */
/*!50002 WITH CASCADED CHECK OPTION */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_orderpayments`
--

/*!50001 DROP VIEW IF EXISTS `view_orderpayments`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_orderpayments` AS select `orders`.`order_id` AS `order_id`,`GetTotalPaid`(`orders`.`order_id`) AS `TotalPaid` from `orders` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_orders`
--

/*!50001 DROP VIEW IF EXISTS `view_orders`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_orders` AS select `orders`.`order_id` AS `order_id`,`orders`.`customer_id` AS `customer_id`,`orders`.`total_amount` AS `total_amount`,`orders`.`status` AS `status` from `orders` */
/*!50002 WITH CASCADED CHECK OPTION */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_ordersummary`
--

/*!50001 DROP VIEW IF EXISTS `view_ordersummary`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_ordersummary` AS select `o`.`order_id` AS `order_id`,`c`.`first_name` AS `first_name`,`c`.`last_name` AS `last_name`,`o`.`total_amount` AS `total_amount`,`o`.`status` AS `status`,`p`.`status` AS `payment_status` from ((`orders` `o` join `customers` `c` on(`o`.`customer_id` = `c`.`customer_id`)) join `payments` `p` on(`o`.`order_id` = `p`.`order_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_topproducts`
--

/*!50001 DROP VIEW IF EXISTS `view_topproducts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_topproducts` AS select `p`.`product_id` AS `product_id`,`p`.`product_name` AS `product_name`,sum(`oi`.`quantity`) AS `total_sold` from (`orderitems` `oi` join `products` `p` on(`oi`.`product_id` = `p`.`product_id`)) group by `p`.`product_id` order by sum(`oi`.`quantity`) desc limit 5 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-19 11:15:57
