using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Domain.Enums;
using BusinessManagement.Infastructure.Repository;
using BusinessManagement.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;

namespace BusinessManagement.Application.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IHttpContextAccessor httpContextAccesssor;
    private readonly IPasswordHasher passwordHasher;
    private readonly IUserRepository userRepository;

    public EmployeeService(IEmployeeRepository employeeRepository,
        IHttpContextAccessor httpContextAccesssor,
        IPasswordHasher passwordHasher,
        IUserRepository userRepository)
    {
        this.employeeRepository = employeeRepository;
        this.httpContextAccesssor = httpContextAccesssor;
        this.passwordHasher = passwordHasher;
        this.userRepository = userRepository;
    }

    public async ValueTask<EmployeeDTO> CreateEmployeeAsync(
        CreationEmployeeDTO creationEmployeeDTO)
    {
        var user = new Users()
        {
            Email = creationEmployeeDTO.email,
            PasswordHash = this.passwordHasher.GeneratePassword(
                creationEmployeeDTO.password,
                Guid.NewGuid().ToString()),
            Roles = creationEmployeeDTO.role
        };

        var createdUser = await this.userRepository.InsertAsync(user);

        var mappedEmployee = EmployeeFactory.MapToEmployee(creationEmployeeDTO);

        var createdEmployee = await this.employeeRepository.InsertAsync(mappedEmployee);

        await this.employeeRepository.SaveChangesAsync();

        return EmployeeFactory.MapToEmployeeDto(createdEmployee);
    }


    public async ValueTask<EmployeeDTO> UpdateEmployeeAsync(
        ModifyEmployeeDTO modifyEmployeeDTO)
    {
        var selectedEmployee = await this.GetEmployeeByExpressionAsync(
            modifyEmployeeDTO.id);

        EmployeeFactory.MapToEmployee(
            employee: selectedEmployee,
            modifyEmployeeDTO: modifyEmployeeDTO);

        var updatedEmployee = await this.employeeRepository
            .UpdateAsync(selectedEmployee);

        await this.employeeRepository.SaveChangesAsync();

        return EmployeeFactory.MapToEmployeeDto(updatedEmployee);
    }

    public IQueryable<EmployeeDTO> RetrieveAllEmployeees(QueryParameter queryParameter)
    {
        var employees = this.employeeRepository.SelectAll();

        var pagedEmployes = employees.PagedList(
            httpContext: httpContextAccesssor.HttpContext,
            queryParameter: queryParameter);

        return pagedEmployes.Select(employee => EmployeeFactory
            .MapToEmployeeDto(employee));
    }

    public async ValueTask<EmployeeDTO> RetrieveEmployeeByIdAsync(Guid id)
    {
        var selectedEmployee = await this.GetEmployeeByExpressionAsync(id);

        return EmployeeFactory.MapToEmployeeDto(selectedEmployee);
    }

    public async ValueTask<EmployeeDTO> DeleteEmployeeAsync(Guid id)
    {
        var selectedEmployee = await this.GetEmployeeByExpressionAsync(id);
        
        var deletedEmployee = await this.employeeRepository.DeleteAsync(selectedEmployee);

        return EmployeeFactory.MapToEmployeeDto(deletedEmployee);
    }
    private async ValueTask<Employees> GetEmployeeByExpressionAsync(Guid id)
    {
        var retrievedEmployee = await this.employeeRepository
            .SelectByIdWithDetailsAsync(employee => employee.Id == id,
            new string[] { "Address", "LegalPerson" });

        return retrievedEmployee;
    }
}
