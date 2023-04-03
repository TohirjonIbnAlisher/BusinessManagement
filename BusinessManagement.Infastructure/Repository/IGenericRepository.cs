using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Infastructure.Repository
{
    public interface IGenericRepository<TEntity, TKey>
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        IQueryable<TEntity> SelectAll();
        ValueTask<TEntity> SelectByIdAsync(TKey id);

        ValueTask<TEntity> SelectByIdWithDetailsAsync(
            Expression<Func<TEntity, bool>> expression,
            string[] includes);

        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<TEntity> DeleteAsync(TEntity entity);
        ValueTask<int> SaveChangesAsync();
    }
}
