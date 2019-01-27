using Coffee.Service.Interface;
using Entity.Model;
using Entity.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Coffee.Service
{
    /// <summary>
    /// The Service Coffee
    /// </summary>
    /// <seealso cref="Coffee.Service.Interface.IServiceCoffee" />
    public class ServiceCoffee : IServiceCoffee
    {
        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #region contructors
        /// <summary>
        /// Constructor to create instance of the _unitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceCoffee(IUnitOfWork injectedUnitOfWork)
        {
            if (injectedUnitOfWork == null)
            {
                throw new ArgumentNullException(nameof(injectedUnitOfWork));
            }
            _unitOfWork = injectedUnitOfWork;
        }
        #endregion

        /// <summary>
        /// Gets the last drink.
        /// </summary>
        /// <param name="badgeId">The badge identifier.</param>
        /// <returns>
        /// Last drink choosed
        /// </returns>
        public Drink GetLastDrink(string badgeId)
        {
           IEnumerable<Drink> drinks = _unitOfWork.DrinkRepository.Get();
            Drink drink = drinks.Where(d => d.BadgeId == badgeId).Select(x => new Drink
            {
                BadgeId = x.BadgeId,
                DrinkId = x.DrinkId,
                SugarQuantity = x.SugarQuantity,
                DrinkDate = x.DrinkDate,
                DrinkType = x.DrinkType,
                UseMug = x.UseMug
            }).OrderByDescending(x => x.DrinkDate).First();
            return drink;
        }

        /// <summary>
        /// Saves the drink.
        /// </summary>
        /// <param name="drink">The drink.</param>
        /// <returns>
        /// the created drink
        /// </returns>
        public Drink SaveDrink(Drink drink)
        {
            _unitOfWork.DrinkRepository.Insert(drink);
            _unitOfWork.Save();
            return drink;
        }
    }
}
