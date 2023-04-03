using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.DbContexts;

namespace BusinessManagement.Infastructure.Repository;

public class LegalPersonRepository : GenericRepository<LegalPersons, Guid>, ILegalPersonRepository
{
    public LegalPersonRepository(BusinessManagementDbContext appDbContext) 
        : base(appDbContext)
    {
    }
}
