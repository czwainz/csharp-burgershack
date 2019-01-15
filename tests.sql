-- CREATE TABLE Burgers (
-- id int NOT NULL AUTO_INCREMENT,
-- name VARCHAR(255),
-- description VARCHAR(255),
-- price int,
-- PRIMARY KEY (id)

-- );

-- INSERT INTO Burgers (name, description, price) VALUES ("Vegetarian", "Not a real burger", 8);
-- INSERT INTO Burgers (name, description, price) VALUES ("Turkey", "Real burger but with turkey", 8);
-- INSERT INTO Burgers (name, description, price) VALUES ("Five Guys", "It's actually a hotdog", 8);


-- SELECT * FROM Burgers WHERE id = 1

UPDATE Burgers SET
name = "Hotdog",
price = 10
WHERE id = 1;
SELECT * FROM Burgers WHERE id = 1;
-- SELECT * FROM Burgers;

-- DELETE FROM Burgers WHERE id = 3;
-- SELECT * FROM Burgers