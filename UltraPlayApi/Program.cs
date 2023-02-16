using Microsoft.EntityFrameworkCore;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Interfaces.Repository;
using UltraPlayApi.Models;
using UltraPlayApi.Repositories;

namespace UltraPlayApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEnumerable<IEvent>, List<Event>>();
            builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();
            builder.Services.AddScoped<IXmlFeedRepository, XmlFeedRepository>();

            builder.Services.AddDbContext<UltraPlayContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("UltraplayConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}