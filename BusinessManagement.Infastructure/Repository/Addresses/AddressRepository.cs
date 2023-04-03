using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.DbContexts;

namespace BusinessManagement.Infastructure.Repository;

public class AddressRepository : GenericRepository<Addresses, Guid>, IAddressRepository
{
    public AddressRepository(BusinessManagementDbContext appDbContext) 
        : base(appDbContext)
    {
    }
}
