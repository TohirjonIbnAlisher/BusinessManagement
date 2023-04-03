using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infastructure.Repository;

public interface IEmployeeRepository : IGenericRepository<Employees, Guid>
{
}
