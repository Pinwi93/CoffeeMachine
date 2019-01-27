using Entity.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Entity.Infra.Core
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The internat context
        /// </summary>
        internal DbContext context;

        /// <summary>
        /// The internal dbset
        /// </summary>
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// The generic repository constructor
        /// </summary>
        /// <param name="context">the context</param>
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The generic get method
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <param name="includeProperties">include Properties</param>
        /// <returns>IEnumerable<TEntity></returns>
        public virtual IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        /// <summary>
        /// The generic insert method
        /// </summary>
        /// <param name="entity">TEntity</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
    }
}
