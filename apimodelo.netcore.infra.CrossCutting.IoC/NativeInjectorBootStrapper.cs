using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Validations;
using apimodelo.netcore.infra.Data.MSSQL.Context;
using apimodelo.netcore.infra.Data.MSSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace apimodelo.netcore.infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ILivrosRepository, LivrosRepository>();
            #endregion

            #region Validations
            services.AddScoped<UsuarioValidations>();
            services.AddScoped<LivrosValidations>();
            services.AddScoped<LoginValidations>();
            #endregion

            services.AddDbContext<Context>(o => o.UseSqlServer("Server=localhost;Database=dbapimodelo;User Id=sa;Password=sa@12345;"));
        }
    }
}
