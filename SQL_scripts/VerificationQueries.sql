-- SQL Verification Queries for Movie Form Testing
-- Use these queries to verify database operations performed by the Movie form

-- =============================================
-- View all movies in the database
-- =============================================
SELECT MovieID, Name, Type, DistributionFee, NumCopies, Rating
FROM MovieRentalDB.dbo.Movies
ORDER BY MovieID;

-- =============================================
-- Verify a specific movie exists by ID
-- =============================================
-- Replace 'M001' with the ID you're looking for
SELECT MovieID, Name, Type, DistributionFee, NumCopies, Rating
FROM MovieRentalDB.dbo.Movies
WHERE MovieID = 'M001';

-- =============================================
-- Verify a specific movie exists by Name
-- =============================================
-- Replace 'Test Movie' with the name you're looking for
SELECT MovieID, Name, Type, DistributionFee, NumCopies, Rating
FROM MovieRentalDB.dbo.Movies
WHERE Name = 'Test Movie';

-- =============================================
-- Count movies of each type
-- =============================================
SELECT Type, COUNT(*) AS MovieCount
FROM MovieRentalDB.dbo.Movies
GROUP BY Type
ORDER BY MovieCount DESC;

-- =============================================
-- Find movies with highest/lowest distribution fee
-- =============================================
-- Highest fee
SELECT TOP 1 MovieID, Name, Type, DistributionFee
FROM MovieRentalDB.dbo.Movies
ORDER BY DistributionFee DESC;

-- Lowest fee
SELECT TOP 1 MovieID, Name, Type, DistributionFee
FROM MovieRentalDB.dbo.Movies
ORDER BY DistributionFee ASC;

-- =============================================
-- Find movies with most/least copies
-- =============================================
-- Most copies
SELECT TOP 1 MovieID, Name, Type, NumCopies
FROM MovieRentalDB.dbo.Movies
ORDER BY NumCopies DESC;

-- Least copies
SELECT TOP 1 MovieID, Name, Type, NumCopies
FROM MovieRentalDB.dbo.Movies
ORDER BY NumCopies ASC;

-- =============================================
-- Database verification after ADD operation
-- =============================================
-- Run this after adding a new movie with ID 'M011'
SELECT * FROM MovieRentalDB.dbo.Movies WHERE MovieID = 'M011';

-- Count total movies (should increase by 1 after adding)
SELECT COUNT(*) AS TotalMovies FROM MovieRentalDB.dbo.Movies;

-- =============================================
-- Database verification after MODIFY operation
-- =============================================
-- Run this after modifying a movie with the name 'Updated Movie'
SELECT * FROM MovieRentalDB.dbo.Movies WHERE Name = 'Updated Movie';

-- =============================================
-- Database verification after DELETE operation
-- =============================================
-- Run this after deleting movie with ID 'M011'
-- Should return 0 rows if deletion was successful
SELECT COUNT(*) AS RemainingMovies 
FROM MovieRentalDB.dbo.Movies 
WHERE MovieID = 'M011';

-- Count total movies (should decrease by 1 after deleting)
SELECT COUNT(*) AS TotalMovies FROM MovieRentalDB.dbo.Movies;

-- =============================================
-- Advanced Queries
-- =============================================

-- Find all movie types available
SELECT DISTINCT Type FROM MovieRentalDB.dbo.Movies ORDER BY Type;

-- Calculate total distribution fees and average copies per type
SELECT 
    Type,
    COUNT(*) AS MovieCount,
    SUM(DistributionFee) AS TotalFees,
    AVG(NumCopies) AS AvgCopies
FROM MovieRentalDB.dbo.Movies
GROUP BY Type
ORDER BY MovieCount DESC;

-- Find movies matching a specific rating
-- Replace 'PG-13' with the rating you're looking for
SELECT MovieID, Name, Type, Rating
FROM MovieRentalDB.dbo.Movies
WHERE Rating = 'PG-13';
