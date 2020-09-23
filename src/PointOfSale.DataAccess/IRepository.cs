using System.Collections.Generic;

namespace PointOfSale.DataAccess
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
