using Microsoft.EntityFrameworkCore;
using SAIM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SAIM.Domain.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region Variables
        private readonly saimContext _Context;
        private readonly DbSet<TEntity> _entities;
        #endregion

        #region Constructor
        public Repository(saimContext context)
        {
            _Context = context;
            _entities = _Context.Set<TEntity>();
        }
        #endregion

        #region Métodos 

        public TEntity GetById(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public TEntity GetById(string id)
        {
            return _Context.Set<TEntity>().Find(id);
        }
        public bool Insert(TEntity entity)
        {
            _entities.Add(entity);
            int changes = _Context.SaveChanges();
            return changes > 0;
        }

        public bool Update(TEntity entity)
        {
            _entities.Update(entity);
            int changes = _Context.SaveChanges();
            return changes > 0;
        }

        public bool Delete(int id)
        {
            TEntity entity = GetById(id);
            _Context.Remove(entity);
            int changes = _Context.SaveChanges();

            return changes > 0;
        }

        public bool Delete(string id)
        {
            TEntity entity = GetById(id);
            _Context.Remove(entity);
            int changes = _Context.SaveChanges();
            return changes > 0;

        }
        public List<TEntity> List(Expression<Func<TEntity, bool>> expresion = null, int? top = null)
        {
            bool topBit = top == null;
            List<TEntity> result;

            if (expresion == null)
            {
                if (topBit)
                {
                    result = ((IQueryable<TEntity>)_entities).ToList();
                }
                else
                {
                    result = ((IQueryable<TEntity>)_entities).TakeLast((int)top).ToList();
                }

            }
            else
            {
                if (topBit)
                {
                    result = ((IQueryable<TEntity>)_entities).Where(expresion).ToList();
                }
                else
                {
                    result = ((IQueryable<TEntity>)_entities).Where(expresion).TakeLast((int)top).ToList();
                }
            }

            return result;

            #endregion
        }
    }
}
