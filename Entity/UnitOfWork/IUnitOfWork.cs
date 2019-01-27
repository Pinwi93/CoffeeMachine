using Entity.Infra.Interface;
using Entity.Model;
using System;

namespace Entity.UnitOfWork
{
    /// <summary>
    /// The IUnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// The CategorieRepository
        /// </summary>
        IGenericRepository<Drink> DrinkRepository { get; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}