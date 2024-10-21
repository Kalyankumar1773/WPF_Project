using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
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
            string constr = string.Empty;
            try
            {
                if (ConfigurationManager.AppSettings["dbConnection"] != null)
                    constr = ConfigurationManager.AppSettings["dbConnection"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (constr != string.Empty) 
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(constr)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(@"Server=SV37\\SQLEXPRESS;Database=TestingDB;Trusted_Connection=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            }

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
