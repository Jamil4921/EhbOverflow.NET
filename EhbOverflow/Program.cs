using System.Data.Entity;

namespace EhbOverflow
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());

            ApplicationConfiguration.Initialize();
            Application.Run(new RegistrationForm());
        }
    }
}