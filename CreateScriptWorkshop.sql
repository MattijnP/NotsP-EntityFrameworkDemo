CREATE DATABASE WorkshopDB;

USE WorkshopDB;

CREATE TABLE dbo.Products(
        ID INT PRIMARY KEY IDENTITY,
        Name VARCHAR(100) NOT NULL,
        Price MONEY NOT NULL,
        Description VARCHAR(500) NULL
);

CREATE TABLE dbo.Customers(
        ID INT PRIMARY KEY IDENTITY,
        Email VARCHAR(50) NOT NULL,
        PasswordHash VARCHAR(50) NOT NULL
);

CREATE TABLE dbo.Orders(
        ID INT PRIMARY KEY IDENTITY,
        CustomerID INT NOT NULL,
        CONSTRAINT PK_CustomerID FOREIGN KEY (CustomerID) REFERENCES dbo.Customers (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE dbo.OrderProducts(
        OrderID INT NOT NULL,
        ProductID INT NOT NULL,
        Quantity INT NOT NULL,
        CONSTRAINT PK_OrderID FOREIGN KEY (OrderID) REFERENCES dbo.Orders (ID) ON DELETE CASCADE ON UPDATE CASCADE,
        CONSTRAINT PK_ProductID FOREIGN KEY (ProductID) REFERENCES dbo.Products (ID) ON DELETE CASCADE ON UPDATE CASCADE,
        PRIMARY KEY (OrderID, ProductID)
);

INSERT INTO Products (Name, Price, Description) VALUES 
('Een tafel', 10.00, 'Leuk voor de dames'),
('Een pistool', 6.00, 'Leuk voor de kinderen'),
('Een mok', 57.99, 'Hele dure en coole mok');

INSERT INTO Customers (Email, PasswordHash) VALUES 
('mattijn@live.nl', '12345'),
('ciyan@live.nl', '23456'),
('bram@gmail.com', '34567'),
('sjoerd@outlook.com', '45678'),
('mees@mees.nl', '56789');

INSERT INTO Orders (CustomerID) VALUES 
(1),
(2);

INSERT INTO OrderProducts (OrderID, ProductID, Quantity) VALUES
(1,1,3),
(1,2,2),
(2,3,10);


