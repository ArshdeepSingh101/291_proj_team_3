# Movie Form Testing Guide

## Setup Instructions

### 1. Database Setup
1. Open SQL Server Management Studio
2. Connect to your SQL Server instance
3. Execute the script in `SQL_scripts/CreateMovieDB.sql` to create the database and populate it with sample data

### 2. Update Connection String (If Needed)
1. Open `DataAccess.cs`
2. Update the connection string to match your SQL Server instance name:
   ```csharp
   private static readonly string connectionString = @"Server=YOUR_SERVER_NAME;Database=MovieRentalDB;Trusted_Connection=True";
   ```
   - Replace `YOUR_SERVER_NAME` with your SQL Server instance (e.g., `localhost` or `YOURMACHINE\SQLEXPRESS`)

### 3. Run the Application
1. Build and run the project
2. The Movie form should launch directly (we modified Program.cs to start with the Movie form)

## Testing the Movie Form

### Basic Functionality
1. **Verify Database Connection**
   - The search dropdown should populate with movie names from the database
   - If not, check your connection string and ensure the database was created

2. **Add a Movie**
   - Fill in all fields:
     - MovieID: (e.g., M011)
     - Movie Name: (e.g., Your Test Movie)
     - Movie Type: (select from dropdown)
     - Distribution Fee: (e.g., 9.99)
     - Number of Copies: (e.g., 5)
     - Rating: (e.g., PG-13)
   - Click "Add" button
   - You should see a success message

3. **Search for a Movie**
   - Use the dropdown to select the movie you just added
   - All form fields should populate with the movie's data

4. **Modify a Movie**
   - With a movie loaded, change some values
   - Click "Modify" button
   - You should see a success message
   - Select the movie again to verify changes were saved

5. **Delete a Movie**
   - With a movie loaded, click "Delete" button
   - Confirm in the dialog
   - You should see a success message
   - Verify the movie no longer appears in the dropdown

### Error Handling
- Try adding a movie without filling all fields (should show error message)
- Try adding a movie with an ID that already exists (should show error message)
- Try entering invalid data in numeric fields (should show error message)

## Troubleshooting

1. **Connection Issues**
   - Verify your SQL Server is running
   - Check that the connection string is correct for your environment
   - Ensure you have permissions to access the database

2. **Missing Movies in Dropdown**
   - Check if the database was created properly
   - Verify the Movies table has data (run `SELECT * FROM MovieRentalDB.dbo.Movies` in SSMS)

3. **Build Errors**
   - Ensure you have the Microsoft.Data.SqlClient package installed
   - Check for any compilation errors in the Error List window

## Next Steps

After verifying the Movie form works correctly, you can:
1. Integrate it with the main navigation system
2. Implement additional features or validations
3. Connect it to the rest of your movie rental application
