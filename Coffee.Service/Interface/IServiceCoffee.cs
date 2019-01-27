using Entity.Model;

namespace Coffee.Service.Interface
{
    /// <summary>
    /// The service coffee interface
    /// </summary>
    public interface IServiceCoffee
    {
        /// <summary>
        /// Gets the last drink.
        /// </summary>
        /// <param name="badgeId">The badge identifier.</param>
        /// <returns>Last drink choosed</returns>
        Drink GetLastDrink(string badgeId);

        /// <summary>
        /// Saves the drink.
        /// </summary>
        /// <param name="drink">The drink.</param>
        /// <returns>the created drink</returns>
        Drink SaveDrink(Drink drink);

    }
}
