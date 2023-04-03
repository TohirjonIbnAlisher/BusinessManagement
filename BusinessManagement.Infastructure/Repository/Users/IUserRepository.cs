using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infastructure.Repository;

public interface IUserRepository : IGenericRepository<Users, Guid>
{
}
