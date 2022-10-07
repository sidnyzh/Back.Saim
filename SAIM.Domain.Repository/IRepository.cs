using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SAIM.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity GetById(int id);

        TEntity GetById(string id);

        bool Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int id);

        bool Delete(string id);

        List<TEntity> List(Expression<Func<TEntity, bool>> expresion = null, int? top = null);
    }
}
