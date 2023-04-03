using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Application.ServiceModel;

namespace BusinessManagement.Application.Services.Employee;

public interface IEmployeeService
{
    ValueTask<EmployeeDTO> CreateEmployeeAsync(
        CreationEmployeeDTO creationEmployeeDTO);
    ValueTask<EmployeeDTO> UpdateEmployeeAsync(
        ModifyEmployeeDTO modifyEmployeeDTO);
    IQueryable<EmployeeDTO> RetrieveAllEmployeees(QueryParameter queryParameter);
    ValueTask<EmployeeDTO> RetrieveEmployeeByIdAsync(Guid id);
    ValueTask<EmployeeDTO> DeleteEmployeeAsync(Guid id);
}
