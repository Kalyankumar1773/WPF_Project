using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using xCubeApplication.ClientDAL;
using xCubeApplication.Services;
using xCubeApplication.ViewModels.Dashboard;

namespace xCubeApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(@"Server=SV37\SQLEXPRESS;Database=TestingDB;Trusted_Connection=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddSingleton<IUserRepositoryService, UserRepositoryService>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<MainWindow>();
        }


        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetService<DashboardViewModel>();
            mainWindow.Show();
        }
    }

}
