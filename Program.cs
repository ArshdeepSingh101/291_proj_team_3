namespace _291_proj
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Uncomment the following line to test database connection
            // and comment out the Application.Run line
            //TestDatabaseConnection.RunTest();
            
            // Normal GUI application startup
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Movie_form());
        }
    }
}
