USE [CMPT291-AS2]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS [Order],
                     QueueUp,
                     Movie,
                     Actor,
                     CustomerPhone,
                     Customer,
                     EmployeePhone,
                     Employee,
                     AppearedIn,
                     RateActor;
GO

--CREATE TABLE [Order] (
--    OrderID INT primary key,
--    CustomerID INT,
--    EmployeeID INT,
--    MovieID INT,
--    CheckoutTime DATETIME NOT NULL,
--    ReturnTime DATETIME NULL,
--    Cust_Rate_Movie INT NOT NULL DEFAULT 0,
--    FOREIGN KEY ( CustomerID ) References Customer ( CustomerID ),
--    FOREIGN KEY ( EmployeeID ) References Employee ( EmployeeID ),
--    FOREIGN KEY ( MovieID ) References Movie ( MovieID ),
--    CONSTRAINT Cust_Rate_Movie CHECK (Cust_Rate_Movie >= 0 AND Cust_Rate_Movie <= 5)
--);

CREATE TABLE Movie (
    MovieID INT primary key,
    MovieName Varchar(40) NOT NULL,
    MovieType Varchar(10)
        CHECK( MovieType='Comedy' or MovieType='Drama' or MovieType='Action' or MovieType='Foreign'),
    DistributionFee NUMERIC(6,2) NOT NULL,
    NumberOfCopies INT NOT NULL
);

CREATE TABLE Actor (
    ActorID INT primary key,
    ActorName Varchar(40) NOT NULL,
    Gender Varchar(10),
    DOB DATE
);

CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    LastName VARCHAR(20) NOT NULL,
    FirstName VARCHAR(20) NOT NULL,
    CustAddress VARCHAR(75),
    CustCity VARCHAR(40),
    CustState VARCHAR(25),
    CustZip VARCHAR(10),  -- Changed to VARCHAR to accommodate ZIP+4 format
    EmailAddress VARCHAR(254),  -- Increased length to accommodate longer email addresses
    AccountNumber VARCHAR(25) NOT NULL UNIQUE,  -- Added UNIQUE constraint
    AccountCreate DATE NOT NULL DEFAULT GETDATE(),  -- Added default value
    CreditCard VARCHAR(16)  -- Changed to VARCHAR(16) and consider encryption
);
--CREATE TABLE Customer (
--    CustomerID INT IDENTITY(1,1) primary key,
--    LastName Varchar(20) NOT NULL,
--    FirstName Varchar(20) NOT NULL,
--    CustAddress Varchar(75),
--    CustCity Varchar(40),
--    CustState Varchar(25),
--    CustZip nchar(6),
--    EmailAddress Varchar(50),
--    AccountNumber Varchar(25) NOT NULL,
--    AccountCreate DATE NOT NULL,
--    CreditCard Varchar(25)
--);

CREATE TABLE Employee (
    EmployeeID INT IDENTITY(1,1),
    SSN nchar(9) NOT NULL,
    LastName Varchar(40) NOT NULL,
    FirstName Varchar(40) NOT NULL,
    -- EmpAddress Varchar(75),
    -- EmpCity Varchar(40),
    -- EmpState Varchar(25)
    -- EmpZip nchar(6),
    StartDate DATE NOT NULL DEFAULT (getdate()),
    PRIMARY KEY(EmployeeID),
    UNIQUE ( SSN )
);

CREATE TABLE EmployeePhone(
    EmployeeID INT NOT NULL,
    PhoneNum nchar(10) NOT NULL,
    PhoneType varchar(10) NOT NULL,
    StartTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    EndTime DATETIME,
    PRIMARY KEY ( EmployeeID, PhoneNum, StartTime ),
    FOREIGN KEY ( EmployeeID ) REFERENCES Employee( EmployeeID ),
    CONSTRAINT EmpPhonePeriod CHECK (StartTime < EndTime),
);

CREATE TABLE CustomerPhone(
    CustomerID INT NOT NULL,
    PhoneNum nchar(10) NOT NULL,
    PhoneType varchar(10) Not NULL,
    StartTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    EndTime Datetime,
    PRIMARY KEY ( CustomerID, PhoneNum, StartTime),
    FOREIGN KEY ( CustomerID) REFERENCES Customer(CustomerID),
    CONSTRAINT CusPhonePeriod CHECK (StartTime < EndTime)
);

CREATE TABLE QueueUp (
    CustomerID INT NOT NULL,
    MovieID INT NOT NULL,
    SortOrder INT IDENTITY(1,1),
    PRIMARY KEY (CustomerID, MovieID, SortOrder),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (MovieID) REFERENCES Movie(MovieID)
);

    
CREATE TABLE AppearedIn (
    ActorID INT NOT NULL,
    MovieID INT NOT NULL,
    PRIMARY KEY (ActorID, MovieID),
    FOREIGN KEY (ActorID) REFERENCES Actor(ActorID),
    FOREIGN KEY (MovieID) REFERENCES Movie(MovieID)
);


CREATE TABLE [Order] (
    OrderID INT primary key,
    CustomerID INT,
    EmployeeID INT,
    MovieID INT,
    CheckoutTime DATETIME NOT NULL,
    ReturnTime DATETIME NULL,
    Cust_Rate_Movie INT NOT NULL DEFAULT 0,
    FOREIGN KEY ( CustomerID ) References Customer ( CustomerID ),
    FOREIGN KEY ( EmployeeID ) References Employee ( EmployeeID ),
    FOREIGN KEY ( MovieID ) References Movie ( MovieID ),
    CONSTRAINT Cust_Rate_Movie CHECK (Cust_Rate_Movie >= 0 AND Cust_Rate_Movie <= 5)
);


CREATE TABLE RateActor (
    ActorID INT NOT NULL,
    OrderID INT NOT NULL,
    ARate INT NOT NULL,
    PRIMARY KEY (ActorID, OrderID),
    FOREIGN KEY (ActorID) REFERENCES Actor(ActorID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);
