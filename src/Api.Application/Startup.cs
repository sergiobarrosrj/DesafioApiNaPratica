using System;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace application
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
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
                        {
                            cfg.AddProfile(new DtoToModelProfile());
                            cfg.AddProfile(new EntityToDtoProfile());
                            cfg.AddProfile(new ModelToEntityProfile());
                        });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Desafio API AspNetCore 2 - Na Prática",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("http://localhost"),
                    Contact = new OpenApiContact
                    {
                        Name = "Sérgio Peres de Barros",
                        Email = "serpb1@gmail.com",
                        Url = new Uri("http://localhost")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("http://localhost")
                    }
                });
            });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio API AspNetCore 2 - Na Prática");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
