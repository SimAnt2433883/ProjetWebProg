using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetWebProg.Auth;
using ProjetWebProg.Configuration;
using ProjetWebProg.Data;
using Serilog;
using System.Text;

namespace ProjetWebProg;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ? Enregistrer le DbContext
        builder.Services.AddDbContext<ProjetWebProgContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetWebProgContext")));

        // For Identity
        builder.Services.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ProjetWebProgContext>()
            .AddDefaultTokenProviders();

        // Adding Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JWT:Audience"],
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
            };
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Host.UseSerilog((context, config) =>
        {
            config.WriteTo.Console()
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithProperty("ApplicationName", context.HostingEnvironment.ApplicationName);
        });

        builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(AutoMapperConfig).Assembly));

        builder.Services.AddScoped<IAuthManager, AuthManager>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}