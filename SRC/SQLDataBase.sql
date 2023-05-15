/* Creating Table */
CREATE TABLE `stocks` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `item` VARCHAR(50) NOT NULL,
  `amount` INT NOT NULL DEFAULT 0,
  `awaiting_delivery` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE
  );
  
 /* Stored Procedure 1 */
 
 DELIMITER --

CREATE PROCEDURE AddDelivery(IN item_name VARCHAR(50), IN amount_delivery VARCHAR(50))
BEGIN
	UPDATE stocks SET awaiting_delivery = awaiting_delivery + amount_delivery WHERE item = item_name;
END--

DELIMITER ;

/* Stored Procedure 2 */

 DELIMITER --

CREATE PROCEDURE Delivered(IN item_name VARCHAR(50), IN amount_delivered VARCHAR(50))
BEGIN
	UPDATE stocks SET awaiting_delivery = awaiting_delivery - amount_delivered, amount = amount + amount_delivered WHERE item = item_name;
END--

DELIMITER ;

/* Stored Procedure 3 */

DELIMITER --

CREATE PROCEDURE AddItem(IN item_name VARCHAR(50))
BEGIN
	INSERT INTO stocks (item) VALUES (item_name);
END--

DELIMITER ;
