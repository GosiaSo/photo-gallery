using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using ImageDatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebAPI
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
            services.AddDbContext<ImageDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ImageDatabase")));
            services.AddControllers();

            services.AddSwaggerGen(e =>
            {
                e.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Image API", Version = "v1"});
            });

            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["AzureSettings:blob"], preferMsi: true).WithName("Default");
                builder.AddQueueServiceClient(Configuration["AzureSettings:queue"], preferMsi: true);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // http://localhost:28143/swagger/index.html 
            app.UseSwagger();
            app.UseSwaggerUI( e =>
            {
                e.SwaggerEndpoint("/swagger/v1/swagger.json", "Image Swagger");
            }
                );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Utwórz nowy Kontener na Bloby je¿eli ten nie istnieje.
            StartupExtensions.InitiateBlobContainer(Configuration["AzureStorage:ConnectionString"], Configuration["AzureStorage:defaultContainer"]);
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }

        public static void InitiateBlobContainer(string connectionSTR, string containerNAME) 
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionSTR, containerNAME);
            blobContainerClient.CreateIfNotExists();
        }
    }
}
