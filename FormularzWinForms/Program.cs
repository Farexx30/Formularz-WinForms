using FormularzWinForms.Models;
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

            var employeeView = FormConfiguration.ServiceProvider.GetRequiredService<EmployeeView>();
            var employeeModel = new Employee();
            var xmlEmployeeSerializer = new XmlSaveToFile();
            var xmlEmployeeDeserializer = new XmlReadFromFile();
            _ = new EmployeePresenter(employeeModel, employeeView, xmlEmployeeSerializer, xmlEmployeeDeserializer);

            Application.Run(employeeView);
        }
       
    }
}