using Microsoft.Extensions.DependencyInjection;
using HKLS_App.Services;
using HKLS_App.Data;
using Microsoft.EntityFrameworkCore;
using HKLS_App.Views;

namespace HKLS_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            MainPage = new NavigationPage(serviceProvider.GetService<LoginPage>());
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Filename=mauiauthapp.db"));

            services.AddSingleton<AuthService>();
            services.AddSingleton<IFCService>();
            services.AddSingleton<LoginPage>();
        }
    }
}
