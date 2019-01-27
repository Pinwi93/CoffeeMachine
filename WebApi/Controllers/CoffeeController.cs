using Coffee.Service.Interface;
using Entity.Model;
using System;
using System.Web.Http;

namespace Coffee.WebAPI.Controllers
{
    [RoutePrefix("api/Drink")]
    public class CoffeeController : ApiController
    {
        /// <summary>
        /// The BizAudience service client instance.
        /// </summary>
        private readonly IServiceCoffee _serviceCoffee;

        /// <summary>
        /// Set the IServiceBizAudienceClient instane with injected instance.
        /// </summary>      
        public CoffeeController(IServiceCoffee injectedserviceCoffee)
        {
            _serviceCoffee = injectedserviceCoffee;
        }

        /// <summary>
        /// Adds the drink.
        /// </summary>
        /// <param name="drink">The drink.</param>
        /// <returns></returns>
        [Route("AddDrink")]
        [HttpPost]
        public Drink AddDrink(Drink drink)
        {
            try
            {
                drink.DrinkDate = DateTime.Now;
                _serviceCoffee.SaveDrink(drink);
                return drink;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Gets the last drink.
        /// </summary>
        /// <param name="badgeId">The badge identifier.</param>
        /// <returns>Last drink </returns>
        [Route("GetLastDrink")]
        [HttpGet]
        public Drink getLastDrink(string badgeId)
        {
            Drink drink = _serviceCoffee.GetLastDrink(badgeId);
            if (drink != null)
            {
                return drink;
            }
            return null;
        }
    }
}