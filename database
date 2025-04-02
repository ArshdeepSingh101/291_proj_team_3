-----------------------------------------------------------------------------------
-- 1. If database is empty create it first.
-----------------------------------------------------------------------------------
IF DB_ID('DB291') IS NULL
    CREATE DATABASE DB291;
GO

--change to DB291
USE DB291;
GO


-----------------------------------------------------------------------------------
-- 2. clean old version if exist.
-----------------------------------------------------------------------------------
-- order matter here, do not move before check

DROP SEQUENCE IF EXISTS Movie_MovieID_Seq;

IF OBJECT_ID('dbo.ActorRate', 'U') IS NOT NULL
    DROP TABLE ActorRate;

IF OBJECT_ID('dbo.RentalRecord', 'U') IS NOT NULL
    DROP TABLE RentalRecord;

IF OBJECT_ID('dbo.ActorAppear', 'U') IS NOT NULL
    DROP TABLE ActorAppear;

IF OBJECT_ID('dbo.Actor', 'U') IS NOT NULL
    DROP TABLE Actor;

IF OBJECT_ID('dbo.CustomerQueue', 'U') IS NOT NULL
    DROP TABLE CustomerQueue;

IF OBJECT_ID('dbo.Movie', 'U') IS NOT NULL
    DROP TABLE Movie;

IF OBJECT_ID('dbo.AppUserPassword', 'U') IS NOT NULL
    DROP TABLE AppUserPassword;

IF OBJECT_ID('dbo.CustomerPhone', 'U') IS NOT NULL
    DROP TABLE CustomerPhone;

IF OBJECT_ID('dbo.AppUser', 'U') IS NOT NULL
    DROP TABLE AppUser;

IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL
    DROP TABLE Customer;

IF OBJECT_ID('dbo.EmployeePhone', 'U') IS NOT NULL
    DROP TABLE EmployeePhone;

IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL
    DROP TABLE Employee;


-----------------------------------------------------------------------------------
-- 3. create tables
-----------------------------------------------------------------------------------

-- Employee 
CREATE TABLE Employee (
    EmployeeID INT IDENTITY(1,1),
    SSN NCHAR(9) NOT NULL,
    LastName VARCHAR(40) NOT NULL,
    FirstName VARCHAR(40) NOT NULL,
    Address VARCHAR(40),
    City VARCHAR(40),
    Province NCHAR(2),
    PostalCode NCHAR(6),
    StartDate DATE NOT NULL,
    PRIMARY KEY( EmployeeID )
);

-- EmployeePhone 
CREATE TABLE EmployeePhone (
    EmployeeID INT NOT NULL,
    PhoneNum NCHAR(10) NOT NULL,
    PhoneType VARCHAR(10) NOT NULL,
    StartTime DATETIME NOT NULL DEFAULT (GETDATE()),
    EndTime DATETIME,
    PRIMARY KEY ( EmployeeID, PhoneNum, StartTime ),
    FOREIGN KEY ( EmployeeID ) REFERENCES Employee( EmployeeID ),
    CONSTRAINT EmpPhonePeriod CHECK (StartTime < EndTime)
);


-- Customer 
CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1),
    SSN NCHAR(9) NOT NULL,
    LastName VARCHAR(40) NOT NULL,
    FirstName VARCHAR(40) NOT NULL,
    Address VARCHAR(40),
    City VARCHAR(40),
    Province NCHAR(2),
    PostalCode NCHAR(6),
    Email VARCHAR(40) NOT NULL,
    AccountNum NCHAR(10) NOT NULL,
    CreditCardNum NCHAR(16) NOT NULL,
    CreditCardExp NCHAR(4) NOT NULL,
    CreditCardCvv NCHAR(3) NOT NULL,
    CreationDate DATE NOT NULL DEFAULT (GETDATE()),
    PRIMARY KEY( CustomerID )
);

-- CustomerPhone 
CREATE TABLE CustomerPhone (
    CustomerID INT NOT NULL,
    PhoneNum NCHAR(10) NOT NULL,
    PhoneType VARCHAR(10) NOT NULL,
    StartTime DATETIME NOT NULL DEFAULT (GETDATE()),
    EndTime DATETIME,
    PRIMARY KEY ( CustomerID, PhoneNum, StartTime ),
    FOREIGN KEY ( CustomerID ) REFERENCES Customer( CustomerID ),
    CONSTRAINT CustPhonePeriod CHECK (StartTime < EndTime)
);

CREATE TABLE AppUser (
    AppUserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(200) NOT NULL,

    Role VARCHAR(20) NOT NULL
        CHECK (Role IN ('Employee','Customer')),

    EmployeeID INT NULL,
    CustomerID INT NULL,

    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
    
);

CREATE TABLE AppUserPassword (
    AppUserID INT NOT NULL PRIMARY KEY,
    PasswordHash VARCHAR(200) NOT NULL,   -- save hash
   

    FOREIGN KEY (AppUserID) REFERENCES AppUser(AppUserID)
        ON DELETE CASCADE
);

-- Movie 
CREATE TABLE Movie (
    MovieID INT NOT NULL,
    MovieName VARCHAR(40) NOT NULL,
    MovieType VARCHAR(10) NOT NULL
        CHECK ( MovieType IN ('Comedy', 'Drama', 'Action', 'Foreign') ),
    Fee NUMERIC(6,2) NOT NULL,
    NumOfCopy INT NOT NULL,
    PRIMARY KEY( MovieID )
);

-- create a MovieID sequence
CREATE SEQUENCE Movie_MovieID_Seq
    START WITH 1000
    INCREMENT BY 1;

-- CustomerQueue
CREATE TABLE CustomerQueue (
    CustomerID INT NOT NULL,
    MovieID INT NOT NULL,
    SortNum INT NOT NULL,
    PRIMARY KEY ( CustomerID, MovieID ),
    UNIQUE ( CustomerID, SortNum ),
    FOREIGN KEY ( CustomerID ) REFERENCES Customer( CustomerID ),
    FOREIGN KEY ( MovieID ) REFERENCES Movie( MovieID )
);

-- Actor 
CREATE TABLE Actor (
    ActorID INT IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Gender NCHAR(1) NOT NULL CHECK ( Gender IN ('M', 'F') ),
    DateOfBrith DATE NOT NULL,
    PRIMARY KEY ( ActorID )
);

-- ActorAppear 
CREATE TABLE ActorAppear (
    MovieID INT NOT NULL,
    ActorID INT NOT NULL,
    PRIMARY KEY ( MovieID, ActorID ),
    FOREIGN KEY ( MovieID ) REFERENCES Movie( MovieID ),
    FOREIGN KEY ( ActorID ) REFERENCES Actor( ActorID )
);

-- RentalRecord 
CREATE TABLE RentalRecord (
    RentalRecordID INT IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    CustomerID INT NOT NULL,
    MovieID INT NOT NULL,
    CheckoutTime DATETIME NOT NULL DEFAULT (GETDATE()),
    ReturnTime DATETIME,
    MovieRate INT,
    PRIMARY KEY( RentalRecordID ),
    FOREIGN KEY ( EmployeeID ) REFERENCES Employee( EmployeeID ),
    FOREIGN KEY ( CustomerID ) REFERENCES Customer( CustomerID ),
    FOREIGN KEY ( MovieID ) REFERENCES Movie( MovieID )
);

-- ActorRate 
CREATE TABLE ActorRate (
    RentalRecordID INT NOT NULL,
    ActorID INT NOT NULL,
    ActorRate INT,
    FOREIGN KEY ( RentalRecordID ) REFERENCES RentalRecord( RentalRecordID ),
    FOREIGN KEY ( ActorID ) REFERENCES Actor( ActorID )
);

PRINT 'Database DB291 Schema has been created successfully!';
GO

INSERT INTO AppUser
    (Username, PasswordHash, Role)
VALUES
    ('testuser', 'bKE9UspwyIPg8LsQHkJaiehiTeUdstI5JZOvaoQRgJA=', 'Employee');


INSERT INTO AppUser
    (Username, PasswordHash, Role)
VALUES
    ('testuser2', 'V85Sz9IMSEyLQVabjEMnT4bEX3fQXoPDAIVNve98nXo=', 'Customer');



INSERT INTO Employee (SSN, LastName, FirstName, Address, City, Province, PostalCode, StartDate)
VALUES
('111111111','Smith','John','101 Apple St','Calgary','AB','T1A1A1','2023-01-01'),
('222222222','Jones','Mary','202 Orange Rd','Calgary','AB','T2B2B2','2023-02-15'),
('333333333','Brown','James','303 Banana Ave','Edmonton','AB','T3C3C3','2023-03-10'),
('444444444','Johnson','Pat','404 Grape Cres','Vancouver','BC','V4B4B4','2023-04-20'),
('555555555','Garcia','Linda','505 Pear Dr','Toronto','ON','M5V1K4','2023-05-05'),
('666666666','Lee','Kevin','606 Peach Ln','Winnipeg','MB','R2M1Y4','2023-06-30');


INSERT INTO Customer
(SSN, LastName, FirstName, Address, City, Province, PostalCode,
 Email, AccountNum, CreditCardNum, CreditCardExp, CreditCardCvv, CreationDate)
VALUES
('987654321','White','Alice','111 Maple St','Calgary','AB','T2N1N4','alice@test.com','ACCT1001','1234567890123456','1225','123','2023-01-10'),
('876543219','Black','Bob','222 Pine Rd','Edmonton','AB','T5T2B2','bob@test.com','ACCT1002','2345678901234567','0525','234','2023-02-10'),
('765432198','Green','Charlie','333 Oak Ave','Vancouver','BC','V6A3C3','charlie@test.com','ACCT1003','3456789012345678','0824','345','2023-03-10'),
('654321987','Red','Diana','444 Cedar Cres','Toronto','ON','M5V1K4','diana@test.com','ACCT1004','4567890123456789','0526','456','2023-04-12'),
('543219876','Gray','Evan','555 Birch Dr','Calgary','AB','T1Y4B4','evan@test.com','ACCT1005','5678901234567890','1226','567','2023-05-15'),
('111222333','Brown','Jake','777 Walnut St','Regina','SK','S4W1A4','jake@demo.com','ACCT2007','7890123456789012','0126','321','2023-07-01'),
('222333444','Miller','Sophie','888 Cedar Rd','Halifax','NS','B3H2B2','sophie@demo.com','ACCT2008','8901234567890123','0326','432','2023-08-05'),
('333444555','Wilson','Tina','999 Ash Ave','Quebec','QC','G1A2B3','tina@demo.com','ACCT2009','9012345678901234','0925','543','2023-12-10'),
('444555666','Taylor','Mark','123 Spruce Dr','Saskatoon','SK','S7K1M4','mark@demo.com','ACCT2010','0123456789012345','0526','654','2024-01-15'),
('555666777','Bell','Lucy','234 Chestnut Ln','Charlottetown','PE','C1A7J7','lucy@demo.com','ACCT2011','1234567890123456','0826','765','2024-03-20'),
('666777888','Adams','Noah','345 Poplar Rd','Yellowknife','NT','X1A2P3','noah@demo.com','ACCT2012','2345678901234567','0127','876','2024-06-25'),
('777888999','Hughes','Mia','456 Fir Ave','Calgary','AB','T2E5R6','mia@demo.com','ACCT2013','3456789012345678','1125','987','2024-09-10'),
('888999000','Reed','Oscar','567 Willow St','Edmonton','AB','T5T2B2','oscar@demo.com','ACCT2014','4567890123456789','0426','111','2025-01-08'),
('999000111','Campbell','Zoe','678 Holly Rd','Toronto','ON','M5R1L4','zoe@demo.com','ACCT2015','5678901234567890','0726','222','2025-03-14'),
('432198765','Blue','Fiona','666 Elm Ln','Winnipeg','MB','R2M1Y4','fiona@test.com','ACCT1006','6789012345678901','0725','678','2023-06-20'),
('000111222','Ross','Ethan','789 Juniper Pl','Winnipeg','MB','R2X0T6','ethan@demo.com','ACCT2016','6789012345678901','1126','333','2025-05-05');


INSERT INTO Movie (MovieID, MovieName, MovieType, Fee, NumOfCopy)
VALUES
(NEXT VALUE FOR Movie_MovieID_Seq, 'Avengers','Action', 4.50, 10),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Frozen','Comedy', 3.50, 8),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Inception','Drama', 5.00, 5),
(NEXT VALUE FOR Movie_MovieID_Seq, 'La La Land','Drama', 3.00, 4),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Kung Fu Hustle','Action', 2.50, 6),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Parasite','Foreign', 3.00, 4),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Iron Man','Action', 4.00, 10),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Captain America','Action', 3.75, 8),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Thor','Action', 4.20, 6),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Black Widow','Action', 3.80, 5),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Doctor Strange','Action', 4.50, 7),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Finding Nemo','Comedy', 2.50, 10),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Toy Story','Comedy', 3.00, 9),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Shrek','Comedy', 2.80, 8),
(NEXT VALUE FOR Movie_MovieID_Seq, 'The Intern','Drama', 3.20, 6),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Interstellar','Drama', 5.50, 4),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Joker','Drama', 4.75, 5),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Ip Man','Action', 3.00, 6),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Titanic','Drama', 4.60, 10),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Mean Girls','Comedy', 2.60, 6),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Up','Comedy', 3.10, 5),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Mulan','Action', 3.40, 7),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Spirited Away','Foreign', 4.00, 6),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Train to Busan','Foreign', 3.90, 5),
(NEXT VALUE FOR Movie_MovieID_Seq, 'Hero','Foreign', 3.50, 8),
(NEXT VALUE FOR Movie_MovieID_Seq, 'The Notebook','Drama', 2.90, 4);


INSERT INTO Actor (Name, Gender, DateOfBrith)
VALUES
('Robert Downey Jr.','M','1965-04-04'),
('Chris Evans','M','1981-06-13'),
('Scarlett Johansson','F','1984-11-22'),
('Leonardo DiCaprio','M','1974-11-11'),
('Emma Stone','F','1988-11-06'),
('Stephen Chow','M','1962-06-22'),
('Tom Holland','M','1996-06-01'),
('Zendaya','F','1996-09-01'),
('Morgan Freeman','M','1937-06-01'),
('Anne Hathaway','F','1982-11-12'),
('Donnie Yen','M','1963-07-27');


INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1000,1),(1000,2),(1000,3); 

INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1002,4);                 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1003,5);                  
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1004,6);     
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1006,7); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1007,8); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1008,8); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1009,9); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1011,10);
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1011,9); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1012,11);
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1013,10);
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1018,9); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1019,11);
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1020,5);
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1021,6); 
INSERT INTO ActorAppear (MovieID, ActorID) VALUES (1012,4);


INSERT INTO RentalRecord
(EmployeeID, CustomerID, MovieID, CheckoutTime, ReturnTime, MovieRate)
VALUES
(1, 7, 1006, '2023-02-10 10:00','2023-02-12 11:00', 5),
(2, 8, 1011, '2023-03-05 09:30','2023-03-07 10:00', 4),
(3, 9, 1012, '2023-05-01 14:00','2023-05-03 15:00', 4),
(4, 10,1008, '2023-05-12 16:00','2023-05-14 08:00', NULL),
(5, 11,1013, '2023-06-20 19:00','2023-06-21 20:00',5),
(6, 12,1000, '2023-07-02 12:00','2023-07-03 12:00',3),
(1, 13,1019, '2023-08-10 09:00','2023-08-12 09:00',5),

-- 2024 rentals
(2, 14,1012, '2024-01-10 10:00','2024-01-11 15:00',4),
(3, 15,1018, '2024-02-15 12:00','2024-02-17 09:00',5),
(4, 16,1007, '2024-03-20 18:00','2024-03-22 08:00',4),
(5, 7, 1014, '2024-05-05 20:00','2024-05-07 11:00',4),
(6, 8, 1015, '2024-06-01 10:00','2024-06-02 09:00',5),
(1, 9, 1016, '2024-07-12 07:00','2024-07-14 09:00',3),
(2, 10,1017, '2024-08-03 10:00','2024-08-05 12:00',5),
(3, 11,1018, '2024-09-10 16:00','2024-09-12 14:00',4),

-- 2025 rentals
(4, 12,1020, '2025-01-15 11:00','2025-01-17 08:00',5),
(5, 13,1025, '2025-02-07 20:00','2025-02-09 19:00',4),
(6, 14,1006, '2025-03-18 14:00','2025-03-19 18:00',4),
(1, 15,1011, '2025-04-22 09:00','2025-04-24 10:00',2),
(2, 16,1019, '2025-05-10 13:00','2025-05-12 10:00',5),
(1, 1, 1000, '2025-03-01 10:00', '2025-03-03 09:00', 5),  
(2, 2, 1000, '2025-03-02 12:00', '2025-03-05 11:00', 4),
(3, 3, 1001, '2025-03-05 15:00', '2025-03-06 15:00', 5),  
(1, 4, 1001, '2025-03-08 19:00', '2025-03-10 10:00', 3),
(2, 5, 1000, '2025-03-10 09:00', '2025-03-11 12:00', 4),
(3, 6, 1002, '2025-03-12 16:00', '2025-03-15 08:00', 5),   

(4, 1, 1003, '2025-04-01 14:00', '2025-04-02 10:00', 4),   
(5, 2, 1004, '2025-04-05 18:00', '2025-04-06 09:00', 5),   
(6, 3, 1000, '2025-04-10 09:00', '2025-04-11 20:00', 5),  
(1, 4, 1001, '2025-04-12 07:00', '2025-04-13 10:00', 2),  
(2, 5, 1002, '2025-04-15 13:00', '2025-04-16 22:00', 5),   
(3, 6, 1005, '2025-04-20 11:00', '2025-04-21 15:00', 4);   

PRINT 'Sample test data inserted successfully!';

