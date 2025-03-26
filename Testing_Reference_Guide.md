# Movie Form Testing Reference Guide

This document serves as the central reference for all testing documentation related to the Movie form application. It explains how to use the various testing resources we've created and how they work together.

## Testing Documentation Overview

We've created a comprehensive suite of testing documents to help you verify the Movie form functionality:

1. **[MovieForm_TestingGuide.md](MovieForm_TestingGuide.md)** - Step-by-step instructions for testing each feature
2. **[SQL_scripts/VerificationQueries.sql](SQL_scripts/VerificationQueries.sql)** - SQL queries to verify database operations
3. **[InputValidation_TestCases.md](InputValidation_TestCases.md)** - Detailed test cases for input validation
4. **[TroubleshootingGuide.md](TroubleshootingGuide.md)** - Solutions for common connectivity issues
5. **[SQL_scripts/CreateMovieDB.sql](SQL_scripts/CreateMovieDB.sql)** - Script to create and populate the database

## Suggested Testing Workflow

Follow this workflow to thoroughly test the Movie form:

### 1. Setup Phase

1. Run `SQL_scripts/CreateMovieDB.sql` in SQL Server Management Studio to create the database
2. Verify the connection string in `DataAccess.cs` points to your SQL Server
3. Optionally run the database connection test by modifying `Program.cs` as described in the troubleshooting guide

### 2. Functional Testing Phase

1. Follow the test scenarios in `MovieForm_TestingGuide.md`:
   - Test 1: Verify database connection and loading
   - Test 2: Adding a new movie
   - Test 3: Searching and loading a movie
   - Test 4: Modifying a movie
   - Test 5: Deleting a movie

2. After each operation, use the corresponding SQL query from `SQL_scripts/VerificationQueries.sql` to verify the database state

### 3. Input Validation Testing Phase

1. Refer to `InputValidation_TestCases.md` and systematically test each validation case:
   - String field validation
   - Numeric field validation 
   - Cross-field validation
   - Form operation tests

### 4. Error Handling Testing Phase

1. Test database error scenarios:
   - Disconnection handling
   - Constraint violations
   - Concurrency issues

2. Test UI error handling:
   - Feedback for invalid inputs
   - Error message clarity
   - Recovery from errors

## Sample Test Plan Execution

Here's an example of how to execute a full test cycle:

1. **Preparation**:
   - Create the database using `SQL_scripts/CreateMovieDB.sql`
   - Document the initial state by running `SELECT COUNT(*) FROM MovieRentalDB.dbo.Movies;`

2. **Test Adding a Movie**:
   - Follow "Test 2" in `MovieForm_TestingGuide.md`
   - Add a new movie with ID 'M011', name 'Test Movie', etc.
   - Verify with `SELECT * FROM MovieRentalDB.dbo.Movies WHERE MovieID = 'M011';`

3. **Test Input Validation**:
   - Try adding a movie with invalid data (from `InputValidation_TestCases.md`)
   - Verify error messages are clear and helpful
   - Test boundary cases (e.g., maximum length names, decimal precision)

4. **Test Modification**:
   - Follow "Test 4" in `MovieForm_TestingGuide.md`
   - Change a movie's properties
   - Verify changes with appropriate SQL query

5. **Test Deletion**:
   - Follow "Test 5" in `MovieForm_TestingGuide.md`
   - Delete a movie and verify it's removed from the database
   - Check cascading effects if applicable

## Troubleshooting and Debugging

If you encounter issues during testing:

1. Check the connection string in `DataAccess.cs`
2. Run the database connection test utility
3. Refer to `TroubleshootingGuide.md` for common problems and solutions
4. Examine any exception messages for specific error codes
5. Verify database state using queries in `SQL_scripts/VerificationQueries.sql`

## Creating Test Reports

After testing, document your findings:

1. **Test Execution Summary**:
   - Features tested
   - Pass/fail results
   - Critical issues discovered

2. **Database Verification**:
   - Include output from verification queries
   - Document any data inconsistencies

3. **Input Validation Results**:
   - Which validation rules worked correctly
   - Any validation gaps or issues

## Regression Testing

After making changes to the Movie form:

1. Repeat the full testing cycle
2. Pay special attention to areas affected by changes
3. Perform cross-feature testing to ensure changes don't impact other functionality

This comprehensive testing approach ensures the Movie form functions correctly, handles data appropriately, and provides a good user experience.
