using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers;
using Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.UserProfiles.Data;
using Bazzar.Infrastructures.Data.EventsSourcings;
using Bazzar.Infrastructures.Data.Fake.Advertisments;
using Bazzar.Infrastructures.Data.SqlServer;
using Bazzar.Infrastructures.Data.SqlServer.Advertisments;
using Bazzar.Infrastructures.Data.SqlServer.UserProfiles;
using EventStore.ClientAPI;
using Framework.Domain.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Bazzar.Endpoints.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Configuration = configuration;
            Environment = environment;
        }
        private IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var esConnection = EventStoreConnection.Create(Configuration["EventStore:ConnectionString"], ConnectionSettings.Create().KeepReconnecting(), Environment.ApplicationName);
            var store = new BazzarEventSource(esConnection);
            services.AddSingleton(esConnection);
            services.AddSingleton<IEventSource>(store);

            services.AddScoped<IAdvertisementsRepository, EfAdvertisementsRepository>();
            services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();
            services.AddScoped<IAdvertisementQueryService, AdvertisementQueryService>();
            services.AddScoped(c => new SqlConnection(Configuration.GetConnectionString("AddvertismentCnn")));
            services.AddScoped<IUnitOfWork, AdvertismentUnitOfWork>();
          
            services.AddDbContext<AdvertismentDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("AddvertismentCnn")));
          
            services.AddScoped<CreateHandler>();
            services.AddScoped<SetTitleHandler>();
            services.AddScoped<UpdateTextHandler>();
            services.AddScoped<UpdatePriceHandler>();
            services.AddScoped<RequestToPublishHandler>();

            services.AddScoped<RegisterUserHandler>();
            services.AddScoped<UpdateUserNameHandler>();
            services.AddScoped<UpdateUserEmailHandler>();
            services.AddScoped<UpdateUserDisplayNameHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Advertisment", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advertisment API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
