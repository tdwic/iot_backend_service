using IoTBackend.Common;
using IoTBackend.Interfaces;
using IoTBackend.Models;
using IoTBackend.Services;
using Microsoft.Extensions.Configuration;

namespace IoTBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
            builder.Services.AddTransient<IMongoDbRepository, MongoDbRepository>();
            builder.Services.AddTransient<IMongoDbContext, MongoDbContext>();

            builder.Services.AddTransient<IDistanceDataService, DistanceDataService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}