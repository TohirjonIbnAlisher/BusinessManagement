using BusinessManagement.Application.Services;
using BusinessManagement.Application.Services.Address;
using BusinessManagement.Application.Services.Employee;
using BusinessManagement.Infastructure.DbContexts;
using BusinessManagement.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;

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

        return services;
    }

    public static IServiceCollection ConfigureRepositories(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
        serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        serviceCollection.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddApplication(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAddressService,AddressService>();
        serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
        serviceCollection.AddScoped<ILegalPersonService, LegalPersonService>();
        serviceCollection.AddScoped<IUsersService, UserService>();

        return serviceCollection;
    }
}
