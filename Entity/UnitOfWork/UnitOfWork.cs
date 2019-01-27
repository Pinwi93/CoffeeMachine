using Entity.Infra.Core;
using Entity.Infra.Interface;
using Entity.Model;
using System;

namespace Entity.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region private properties

        /// <summary>
        /// The context
        /// </summary>
        private readonly CoffeeContext _context;

        /// <summary>
        /// The Drink Repository
        /// </summary>
        private IGenericRepository<Drink> _DrinkRepository;

        /// <summary>
        /// Disposed attribute
        /// </summary>
        private bool disposed = false;

        #endregion

        #region constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(CoffeeContext context)
        {
            _context = context;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Get Drink Repository.
        /// </summary>
        public IGenericRepository<Drink> DrinkRepository
        {
            get { return this._DrinkRepository ?? (this._DrinkRepository = new GenericRepository<Drink>(_context)); }
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Dispose context method
        /// </summary>
        /// <param name="disposing">Disposing value</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Save change method
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Dispose Method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion  class UnitOfWork
    }
}
