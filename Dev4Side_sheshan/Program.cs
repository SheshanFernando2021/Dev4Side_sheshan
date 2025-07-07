
using Dev4Side_sheshan.Data;
using Dev4Side_sheshan.Repos;
using Dev4Side_sheshan.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dev4Side_sheshan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext: Check ✅
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //DI : Check ✅
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IListRepo, ListRepo>();
            builder.Services.AddScoped<ITaskRepo, TaskRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IListService, ListService>();
            builder.Services.AddScoped<ITaskService, TaskService>();

            //JWT : Check ✅
            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                }; 
            });

            //Authorization : check✅

            builder.Services.AddAuthorization();

            // CORS: check ✅
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    builder => builder
                        .WithOrigins(
                            "http://localhost:5174",
                            "https://spectacular-marshmallow-96df42.netlify.app"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            var app = builder.Build();

            // Development Mode : check✅
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
