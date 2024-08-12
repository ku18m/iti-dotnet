
using ITI_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ITI_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var policyName = "CORSAllowAll";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ITIContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                opt => {

                    opt.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Version = "v1",
                        Title = "ITI API",
                        Description = "api to manage ITI Departments and Students",
                        TermsOfService = new Uri("http://tempuri.org/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Mohamed Kamal",
                            Email = "ku18mz@gmail.com"
                        }
                    });

                    opt.IncludeXmlComments("D:\\ITI\\Repos\\iti-dotnet\\labs\\Server_Side\\Web API\\Day_2\\ITI API\\Documentation.xml");
                    opt.EnableAnnotations();
                }
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
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

            app.UseCors(policyName);

            app.MapControllers();

            app.Run();
        }
    }
}
