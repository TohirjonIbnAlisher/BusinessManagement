using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class EmployeeFactory
{
    internal static Employees MapToEmployee(
        CreationEmployeeDTO creationEmployeeDTO)
    {
        return new Employees();
    }

    internal static void MapToEmployee(
        Employees employee,
        ModifyEmployeeDTO modifyEmployeeDTO)
    {

    }

    internal static EmployeeDTO MapToEmployeeDto(
        Employees employee)
    {
        return new EmployeeDTO();
    }
}
