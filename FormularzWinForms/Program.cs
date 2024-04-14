using FormularzWinForms.Models.Configurations;
using FormularzWinForms.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace FormularzWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = FormConfiguration.CreateHostBuilder().Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            FormConfiguration.ServiceProvider = builder.Services;

            Application.Run(FormConfiguration.ServiceProvider.GetRequiredService<EmployeeView>());
        }
       
    }
}