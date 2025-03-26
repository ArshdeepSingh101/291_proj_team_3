USE [CMPT291-AS2]

DELETE FROM RateActor;
DELETE FROM [Order];
DELETE FROM QueueUp;
DELETE FROM CustomerPhone;
DELETE FROM EmployeePhone;
DELETE FROM AppearedIn;
DELETE FROM Customer;
DBCC CHECKIDENT('customer', RESEED, 0);
DELETE FROM Employee;
DBCC CHECKIDENT('Employee', RESEED, 0);
DELETE FROM Movie;
DELETE FROM Actor;



/****   Actor   ****/
INSERT INTO Actor (ActorID, ActorName, Gender, DOB)
VALUES (1, 'Tom Hanks', 'Male', '1956-07-09');

INSERT INTO Actor (ActorID, ActorName, Gender, DOB)
VALUES (2, 'Meryl Streep', 'Female', '1949-06-22');

INSERT INTO Actor (ActorID, ActorName, Gender, DOB)
VALUES (3, 'Morgan Freeman', 'Male', '1937-06-01');



/****   Movie   ****/
INSERT INTO Movie (MovieID, MovieName, MovieType, DistributionFee, NumberOfCopies)
VALUES (1, 'Forrest Gump', 'Drama', 15.50, 10);

INSERT INTO Movie (MovieID, MovieName, MovieType, DistributionFee, NumberOfCopies)
VALUES (2, 'Avengers', 'Action', 20.00, 20);

INSERT INTO Movie (MovieID, MovieName, MovieType, DistributionFee, NumberOfCopies)
VALUES (3, 'Meet the Parents', 'Comedy', 10.00, 5);



/**** CUSTOMER ****/
INSERT INTO Customer
    (LastName, FirstName, CustAddress, CustCity, CustState, CustZip, EmailAddress,
     AccountNumber, AccountCreate, CreditCard)
VALUES
    ('Smith', 'John', '123 Main St', 'New York', 'NY', '10001',
     'john.smith@example.com', 'ACCT123', '2021-01-01', '4111111111111111');

INSERT INTO Customer
    (LastName, FirstName, CustAddress, CustCity, CustState, CustZip, EmailAddress,
     AccountNumber, AccountCreate, CreditCard)
VALUES
    ('Doe', 'Jane', '456 Elm St', 'Los Angeles', 'CA', '90001',
     'jane.doe@example.com', 'ACCT456', '2021-02-15', '4222222222222222');

INSERT INTO Customer
    (LastName, FirstName, CustAddress, CustCity, CustState, CustZip, EmailAddress,
     AccountNumber, AccountCreate, CreditCard)
VALUES
    ('Brown', 'Alice', '789 Oak Ave', 'Chicago', 'IL', '60601',
     'alice.brown@example.com', 'ACCT789', '2021-03-10', '4333333333333333');
SELECT CustomerID, LastName, FirstName FROM Customer;


/**** Employee   ****/
INSERT INTO Employee (SSN, LastName, FirstName)
VALUES ('123456789', 'Johnson', 'Mark');

INSERT INTO Employee (SSN, LastName, FirstName)
VALUES ('987654321', 'White', 'Susan');

INSERT INTO Employee (SSN, LastName, FirstName)
VALUES ('555555555', 'Green', 'Michael');

SELECT EmployeeID, LastName, FirstName FROM Employee;



/**** Customer Phone  ****/
INSERT INTO CustomerPhone (CustomerID, PhoneNum, PhoneType)
VALUES (1, '5551234567', 'Mobile');

INSERT INTO CustomerPhone (CustomerID, PhoneNum, PhoneType)
VALUES (2, '5559876543', 'Home');

INSERT INTO CustomerPhone (CustomerID, PhoneNum, PhoneType)
VALUES (3, '5555557890', 'Work');



/**** Employee Phone   ****/
INSERT INTO EmployeePhone (EmployeeID, PhoneNum, PhoneType)
VALUES (1, '4441234567', 'Mobile');

INSERT INTO EmployeePhone (EmployeeID, PhoneNum, PhoneType)
VALUES (2, '4449876543', 'Home');

INSERT INTO EmployeePhone (EmployeeID, PhoneNum, PhoneType)
VALUES (3, '4445557890', 'Work');



/****  Appearedln     ****/
INSERT INTO AppearedIn (ActorID, MovieID)
VALUES (1, 1);  -- Tom Hanks in Forrest Gump

INSERT INTO AppearedIn (ActorID, MovieID)
VALUES (2, 3);  -- Meryl Streep in Meet the Parents

INSERT INTO AppearedIn (ActorID, MovieID)
VALUES (3, 2);  -- Morgan Freeman in Avengers


/**** Order   ****/
INSERT INTO [Order] (OrderID, CheckoutTime)
VALUES (1, '2021-08-01 10:00:00');

INSERT INTO [Order] (OrderID, CheckoutTime)
VALUES (2, '2021-08-02 11:00:00');

INSERT INTO [Order] (OrderID, CheckoutTime, ReturnTime)
VALUES (3, '2021-08-03 12:00:00', '2021-08-04 09:00:00');



/**** Actor Rate   ****/
INSERT INTO RateActor (ActorID, OrderID, ARate)
VALUES (1, 1, 5);  

INSERT INTO RateActor (ActorID, OrderID, ARate)
VALUES (2, 2, 4);  

INSERT INTO RateActor (ActorID, OrderID, ARate)
VALUES (3, 3, 5); 
