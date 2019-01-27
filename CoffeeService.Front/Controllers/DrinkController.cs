using AutoMapper;
using CoffeeService.Front.Models.ViewData;
using CoffeeService.Front.Utils;
using Entity.Model;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoffeeService.Front.Controllers
{
    /// <summary>
    /// The Drink Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class DrinkController : Controller
    {
        // GET: Drink
        /// <summary>
        /// Index Action.
        /// </summary>
        /// <returns></returns>
        public async Task< ActionResult >Index()
        {
            DrinkViewData drinkViewData = new DrinkViewData();
            bool isOk = await drinkViewData.Initialize(null);
            return View(drinkViewData);
        }

        /// <summary>
        /// Adds the new drink.
        /// </summary>
        /// <param name="drinkViewData">The drink view data.</param>
        /// <returns>View</returns>
        public async Task<ActionResult> AddNewDrink(DrinkViewData drinkViewData)
        {
            //Mapping the DrinkFormData with the drink
            Drink drink = Mapper.Map<Drink>(drinkViewData.drinkFormData);
            //Make de the web Api Call to post drink
            var drinkItemData = await WebApiClient.PostFormJsonAsync<Drink, Drink>(@"Drink/AddDrink", drink);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Find the last drink.
        /// </summary>
        /// <param name="badgeId">The badge identifier.</param>
        /// <returns>The Partial View</returns>
        public async Task<ActionResult> FindLastDrink(string badgeId)
        {
            DrinkViewData drinkViewData = new DrinkViewData();
            bool isOk = await drinkViewData.Initialize(badgeId);
            if (isOk)
            {
                return PartialView("Partial/_PartialDrink", drinkViewData.drinkFormData);
            }
            return View();
        }
    }
}