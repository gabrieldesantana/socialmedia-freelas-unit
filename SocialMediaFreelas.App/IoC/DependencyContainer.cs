using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace SocialMediaFreelas.IoC
{
    public static class DependencyContainer
    {
        public static void AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IVagaService, VagaService>();
            services.AddScoped<IExperienciaService, ExperienciaService>();
            #endregion

            #region Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IVagaRepository, VagaRepository>();
            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            #endregion

            #region Data_context
            var connectionString = configuration.GetConnectionString("SqliteConnectionString");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
            #endregion

            #region JsonConfiguration
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            #endregion

            #region Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialMediaFreelas.API", Description = "Backend for SocialMediaFreelasApp", Version = "v1" });
            });
            #endregion

            #region RazorPages
            services.AddRazorPages();
            #endregion

        }
    }
}
