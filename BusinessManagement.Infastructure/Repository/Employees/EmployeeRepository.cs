using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.DbContexts;

namespace BusinessManagement.Infastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employees, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(BusinessManagementDbContext appDbContext) 
            : base(appDbContext)
        {
        }
    }
}
