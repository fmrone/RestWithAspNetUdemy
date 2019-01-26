using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAspNetUdemy.Services;
using RestWithAspNetUdemy.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestWithAspNetUdemy.Model.Context;
using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Repository;
using RestWithAspNetUdemy.Repository.Implementations;
using RestWithAspNetUdemy.Repository.Generic;
using Microsoft.Net.Http.Headers;

namespace RestWithAspNetUdemy
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];

            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true // não permite apagar os dados ao realizar alteração na base de dados.
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed!", ex);

                    throw;
                }
            }

            // Add framework services
            services.AddMvc(options => 
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters();

            services.AddApiVersioning();

            // Add dependency injection
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            // Add dependency injection of GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
