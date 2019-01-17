-- CREATE TABLE Customers (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY(id)
-- );

-- SELECT * FROM Customers;


-- CREATE TABLE CustomerBurgers (
-- id int NOT NULL AUTO_INCREMENT,
-- customerId int NOT NULL,
-- burgerId int NOT NULL,

-- PRIMARY KEY (id),
-- INDEX (customerId, burgerId),

-- FOREIGN KEY (customerId)
--   REFERENCES Customers(id)
--      ON DELETE CASCADE,

-- FOREIGN KEY (burgerId)
--    REFERENCES Burgers(id)
--     ON DELETE CASCADE
-- );


SELECT * FROM CustomerBurgers;