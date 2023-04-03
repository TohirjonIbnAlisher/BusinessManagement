using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BusinessManagement.Infastructure.DbContexts;

public class BusinessManagementDbContext : DbContext
{
	public BusinessManagementDbContext(
		DbContextOptions<BusinessManagementDbContext> dbContextOptionsBuilder)
		: base(dbContextOptionsBuilder)
	{

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
