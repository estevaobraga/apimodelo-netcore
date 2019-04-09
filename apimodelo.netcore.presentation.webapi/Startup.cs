using apimodelo.netcore.infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace apimodelo.netcore.presentation.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.ConfigureSwaggerGen(x =>
            //{
            //    x.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            //    x.OperationFilter<ProducesOperatioFilter>();
            //    x.OperationFilter<FormFileSwaggerFilter>();
            //});

            //Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API Modelo",
                    Description ="Exemplo de API usando padrão DDD",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Estêvão Braga",
                        Email = string.Empty,
                        Url = "https://github.com/estevaobraga"
                    }
                });
            });

            //Injeções de dependencia 
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"../swagger/v1/swagger.json", "apimodelo");
            });

            app.UseMvc();
        }
    }
}
