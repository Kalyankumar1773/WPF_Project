using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using xCubeApplication.ClientDAL;
using xCubeApplication.Interfaces;
using xCubeApplication.Services;
using xCubeApplication.ViewModels.Dashboard;

namespace xCubeApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly ServiceProvider _serviceProvider;

        //public App()
        //{
        //    var services = new ServiceCollection();
        //    ConfigureServices(services);
        //    _serviceProvider = services.BuildServiceProvider();
        //}

        //private void ConfigureServices(ServiceCollection services)
        //{
        //    // Register DbContext
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(@"Server=localhost;Database=TestingDB;Trusted_Connection=True;"));

        //    // Register repositories and Unit of Work
        //    services.AddScoped<IUserRepositoryService, UserRepositoryService>();

        //    // Register ViewModel
        //    services.AddSingleton<DashboardViewModel>();
        //}

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    var mainWindow = _serviceProvider.GetService<MainWindow>();
        //    mainWindow.DataContext = _serviceProvider.GetService<DashboardViewModel>();
        //    mainWindow.Show();
        //}
    }

}
