using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity toCreate);
        bool Delete(TEntity toDelete);
        bool Update(TEntity toUpdate);
        TEntity Retrieve(Expression<Func<TEntity, bool>> criteria);
        List<TEntity> RetrieveAllOrder(Expression<Func<TEntity, string>> criteria);
        List<TEntity> Filter(Expression<Func<TEntity, bool>> criteria);
    }
}
