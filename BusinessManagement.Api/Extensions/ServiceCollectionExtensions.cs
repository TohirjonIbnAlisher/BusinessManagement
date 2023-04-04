using BusinessManagement.Application.Services;
using BusinessManagement.Application.Services.Address;
using BusinessManagement.Application.Services.Employee;
using BusinessManagement.Domain.Enums;
using BusinessManagement.Infastructure.DbContexts;
using BusinessManagement.Infastructure.Repository;
using BusinessManagement.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BusinessManagement.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContexts(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSqlConnectionString");
        services.AddDbContextPool<BusinessManagementDbContext>(options =>
        {
            options.UseNpgsql(connectionString, npgslOption =>
            {
                npgslOption.EnableRetryOnFailure();
            });
        });

        services.Configure<JwtOptions>(configuration.GetSection("JwtSettings"));

        services.AddSwaggerService();

        return services;
    }

    public static IServiceCollection ConfigureRepositories(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
        serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        serviceCollection.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddTransient<IGenerateToken, GenerateToken>();
        serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();

        return serviceCollection;
    }

    public static IServiceCollection AddApplication(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAddressService,AddressService>();
        serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
        serviceCollection.AddScoped<ILegalPersonService, LegalPersonService>();
        serviceCollection.AddScoped<IUsersService, UserService>();
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();


        serviceCollection.AddHttpContextAccessor();

        return serviceCollection;
    }

    public static IServiceCollection AutentificationService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy",
                options => {
                    options.RequireRole(Roles.SystemManager.ToString(),
                    Roles.BusinessManager.ToString(),
                    Roles.PhysicalPerson.ToString());
                });
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }

    private static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusinessManagement.Api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }

}
