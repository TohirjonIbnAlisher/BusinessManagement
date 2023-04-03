﻿using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.DbContexts;

namespace BusinessManagement.Infastructure.Repository;

public class UserRepository : GenericRepository<Users, Guid>
{
    public UserRepository(BusinessManagementDbContext appDbContext) 
        : base(appDbContext)
    {
    }
}
