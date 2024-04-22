using FormularzWinForms.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FormularzWinForms.Models.Configurations
{
    public static class FormConfiguration
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.RegisterServices();
               });

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IXmlSaveToFile, XmlSaveToFile>();
            services.AddTransient<IXmlReadFromFile, XmlReadFromFile>();
            services.AddTransient<IEmployeeModel, Employee>();
            services.AddTransient<IEmployeeView, EmployeeView>();
            services.AddTransient<IEmployeePresenter, EmployeePresenter>();

            return services;
        }
    }
}
