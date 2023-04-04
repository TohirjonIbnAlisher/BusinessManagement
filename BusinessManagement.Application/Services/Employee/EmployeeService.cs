using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Domain.Entities;
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
    private readonly IAddressRepository addressRepository;

    public EmployeeService(IEmployeeRepository employeeRepository,
        IHttpContextAccessor httpContextAccesssor,
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IAddressRepository addressRepository)
    {
        this.employeeRepository = employeeRepository;
        this.httpContextAccesssor = httpContextAccesssor;
        this.passwordHasher = passwordHasher;
        this.userRepository = userRepository;
        this.addressRepository = addressRepository;
    }

    public async ValueTask<EmployeeDTO> CreateEmployeeAsync(
        CreationEmployeeDTO creationEmployeeDTO)
    {
        var salt = Guid.NewGuid().ToString();
        var user = new Users()
        {
            Id = Guid.NewGuid(),
            Email = creationEmployeeDTO.email,
            PasswordHash = this.passwordHasher.GeneratePassword(
                creationEmployeeDTO.password,
                salt),
            Roles = creationEmployeeDTO.role,
            Salt = salt
        };

        var employee = new Employees();

        var createdUser = await this.userRepository.InsertAsync(user);
        employee.UserId = createdUser.Id;

        var mappedAddress = AddressFactory.MapToAddress(creationEmployeeDTO.CreationAddressDTO);

        var createdAddress = await this.addressRepository.InsertAsync(mappedAddress);
        employee.AddressId = createdAddress.Id;

        var mappedEmployee = EmployeeFactory.MapToEmployee(
            creationEmployeeDTO,
            employee);

        var createdEmployee = await this.employeeRepository.InsertAsync(mappedEmployee);

        await this.employeeRepository.SaveChangesAsync();

        return EmployeeFactory.MapToEmployeeDto(createdEmployee);
    }


    public async ValueTask<EmployeeDTO> UpdateEmployeeAsync(
        ModifyEmployeeDTO modifyEmployeeDTO)
    {
        var selectedEmployee = await this.GetEmployeeByExpressionAsync(
            modifyEmployeeDTO.id);

        AddressFactory.MapToAddress(
            modifyEmployeeDTO.addressDTO,
            selectedEmployee.Address);
        var updatedAddress = await this.addressRepository.UpdateAsync(selectedEmployee.Address);

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
        await this.userRepository.DeleteAsync(selectedEmployee.User);
        await this.addressRepository.DeleteAsync(selectedEmployee.Address);

        await this.employeeRepository.SaveChangesAsync();

        return EmployeeFactory.MapToEmployeeDto(deletedEmployee);
    }
    private async ValueTask<Employees> GetEmployeeByExpressionAsync(Guid id)
    {
        var retrievedEmployee = await this.employeeRepository
            .SelectByIdWithDetailsAsync(employee => employee.Id == id,
            new string[] { "Address", "LegalPerson", "User" });

        return retrievedEmployee;
    }
}
