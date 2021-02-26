using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IccBot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IccDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=IccDb;Trusted_Connection=True;MultipleActiveResultSets=true",
                    x => x.MigrationsAssembly("DAL.Migrations"));
            });

            var serviceProvider = services.BuildServiceProvider();

            var bot = new Bot(serviceProvider);

            services.AddSingleton(bot);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
