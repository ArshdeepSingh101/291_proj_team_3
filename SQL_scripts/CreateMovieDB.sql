-- Create a new database
USE master;
GO

-- Check if the database already exists and drop it if it does
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'MovieRentalDB')
BEGIN
    ALTER DATABASE MovieRentalDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MovieRentalDB;
END
GO

-- Create the new database
CREATE DATABASE MovieRentalDB;
GO

-- Switch to the new database
USE MovieRentalDB;
GO

-- Create the Movies table
CREATE TABLE Movies (
    MovieID NVARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50),
    DistributionFee DECIMAL(10, 2),
    NumCopies INT,
    Rating NVARCHAR(10)
);
GO

-- Insert sample data
INSERT INTO Movies (MovieID, Name, Type, DistributionFee, NumCopies, Rating)
VALUES 
    ('M001', 'The Shawshank Redemption', 'Drama', 12.99, 10, 'R'),
    ('M002', 'The Godfather', 'Crime', 14.99, 8, 'R'),
    ('M003', 'The Dark Knight', 'Action', 15.99, 15, 'PG-13'),
    ('M004', 'Pulp Fiction', 'Crime', 11.99, 12, 'R'),
    ('M005', 'Forrest Gump', 'Drama', 10.99, 20, 'PG-13');
GO

-- Additional movie types for the dropdown
INSERT INTO Movies (MovieID, Name, Type, DistributionFee, NumCopies, Rating)
VALUES 
    ('M006', 'The Matrix', 'Sci-Fi', 13.99, 15, 'R'),
    ('M007', 'Jurassic Park', 'Adventure', 12.99, 18, 'PG-13'),
    ('M008', 'The Lion King', 'Animation', 9.99, 25, 'G'),
    ('M009', 'Titanic', 'Romance', 10.99, 20, 'PG-13'),
    ('M010', 'The Exorcist', 'Horror', 11.99, 10, 'R');
GO

-- Verify the data was inserted
SELECT * FROM Movies;
GO

PRINT 'Database setup complete!';
GO
