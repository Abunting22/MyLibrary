
using MyLibrary.Server.Controllers;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Repositories;
using MyLibrary.Server.Services;

namespace MyLibrary.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigin = "_myAllowSpecificOrigin";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigin,
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:5173",
                            "https://localhost:7284");
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBaseRepository, BaseRepository>();
            builder.Services.AddScoped<IFictionRepository, FictionRepository>();
            builder.Services.AddScoped<IFictionService, FictionService>();
            builder.Services.AddScoped<FictionController>();
            builder.Services.AddScoped<INonfictionRepository, NonfictionRepository>();
            builder.Services.AddScoped<INonfictionService, NonfictionService>();
            builder.Services.AddScoped<NonfictionController>();
            builder.Services.AddScoped<Book>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigin);

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
