# Movie Form Testing Guide

This guide provides comprehensive testing procedures for the Movie form application's database functionality. It includes step-by-step instructions and SQL queries to verify operations are working correctly.

## Prerequisites

1. SQL Server is set up and accessible from your machine
2. Connection string is correctly configured in `DataAccess.cs`
3. The MovieRentalDB database has been created using the script in `SQL_scripts/CreateMovieDB.sql`

## Opening the Application

1. Ensure `Program.cs` is configured to launch the Movie form:
   ```csharp
   // Make sure this line is uncommented
   ApplicationConfiguration.Initialize();
   Application.Run(new Movie_form());
   
   // And this line is commented out
   // TestDatabaseConnection.RunTest();
   ```

2. Build and run the application:
   ```
   dotnet build
   dotnet run
   ```

3. The Movie form should launch and display the management interface

## Test 1: Verifying Database Connection and Loading Movies

### Expected Behavior
- The search dropdown should populate with movie names from the database
- No error messages should appear

### Verification SQL
Run this in SQL Server Management Studio (SSMS) to verify movies are in the database:
```sql
SELECT * FROM MovieRentalDB.dbo.Movies;
```

### Troubleshooting
If the dropdown is empty:
- Check connection string in `DataAccess.cs`
- Verify SQL Server is running
- Run the connection test utility

## Test 2: Adding a New Movie

### Testing Steps
1. Enter the following information:
   - MovieID: `M011`
   - Movie Name: `Test Movie`
   - Movie Type: Select any type from the dropdown (e.g., `Drama`, `Action`, etc.)
   - Distribution Fee: `9.99`
   - Number of Copies: `5`
   - Rating: `PG-13`
2. Click the "Add" button
3. A success message should appear

### Verification SQL
Run this in SSMS to verify the movie was added:
```sql
SELECT * FROM MovieRentalDB.dbo.Movies WHERE MovieID = 'M011';
```

The output should show one row with the values you entered.

### Alternative Test Data Sets
Test with different data to verify edge cases:
- Use decimal values with more digits: `123.45`
- Try longer movie names: `The Incredibly Long Movie Title That Nobody Would Remember`
- Test with different movie types

## Test 3: Searching and Loading a Movie

### Testing Steps
1. Use the search dropdown to select "Test Movie" (the movie you just added)
2. All fields should populate with the movie's data

### Expected Results
- MovieID field should show `M011`
- Movie Name field should show `Test Movie`
- Movie Type dropdown should show `Action`
- Distribution Fee field should show `9.99`
- Number of Copies field should show `5`
- Rating field should show `PG-13`
- Movie name in label at top should update to: "Movie: Test Movie"

## Test 4: Modifying a Movie

### Testing Steps
1. Select an existing movie using the search dropdown
2. Change these values:
   - Movie Name: `Updated Movie`
   - Number of Copies: `10`
3. Click the "Modify" button
4. A success message should appear

### Verification SQL
Run this SQL to verify the changes:
```sql
SELECT * FROM MovieRentalDB.dbo.Movies WHERE Name = 'Updated Movie';
```

You should see the updated movie record with the new values.

## Test 5: Deleting a Movie

### Testing Steps
1. Select an existing movie using the search dropdown
2. Click the "Delete" button
3. A confirmation dialog should appear - click "Yes"
4. A success message should appear

### Verification SQL
If you deleted movie with ID 'M011', run:
```sql
SELECT * FROM MovieRentalDB.dbo.Movies WHERE MovieID = 'M011';
```

This should return no results, confirming the movie was deleted.

## Test 6: Input Validation

### Test Case 6.1: Empty Fields
1. Clear all fields (or leave some empty)
2. Click the "Add" button
3. An error message about required fields should appear

### Test Case 6.2: Invalid Numeric Values
1. Enter letters in numeric fields:
   - Distribution Fee: `abc`
   - Number of Copies: `xyz`
2. Click the "Add" button
3. An error message about invalid numeric values should appear

### Test Case 6.3: Duplicate Movie ID
1. Try to add a movie with an ID that already exists in the database
2. Click the "Add" button
3. An error message about duplicate ID should appear

## Common Problems and Solutions

### Movie Form Doesn't Launch
- Check for build errors
- Verify `Program.cs` is correctly set to launch the Movie form

### Error During Database Operations
- Check the error message for details
- Verify the database connection using the test utility
- Ensure SQL Server is running and accessible

### Movies Not Appearing in Dropdown
- Check if `GetAllMovies()` method is returning data
- Verify the database contains movie records
- Check connection string and database name

### Buttons Not Working
- Ensure event handlers are properly connected
- Check for JavaScript console errors if using web interface

## Running Full Regression Test

To verify all functionality, follow these steps in order:
1. Add a new movie
2. Search for and verify the movie details
3. Modify the movie
4. Verify the changes persisted
5. Delete the movie
6. Verify the movie was removed

If all these tests pass, the Movie form is functioning correctly.
