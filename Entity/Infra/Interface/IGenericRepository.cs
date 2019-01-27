using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Entity.Infra.Interface
{
    /// <summary>
    /// The IGenericRepository interface
    /// </summary>
    /// <typeparam name="TEntity">TEntity</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The generic insert method
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Insert(TEntity entity);

        /// <summary>
        /// The generic get method
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>IEnumerable<TEntity></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

    }
}
