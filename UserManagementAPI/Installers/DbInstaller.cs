using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagementAPI.Services;

namespace UserManagementAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
