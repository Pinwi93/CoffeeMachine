using AutoMapper;
using CoffeeService.Front.Models.FormData;
using CoffeeService.Front.Models.ItemData;
using CoffeeService.Front.Utils;
using System.Threading.Tasks;

namespace CoffeeService.Front.Models.ViewData
{
    /// <summary>
    /// The Drink View Data
    /// </summary>
    public class DrinkViewData
    {
        /// <summary>
        /// Gets or sets the drink form data.
        /// </summary>
        public DrinkFormData drinkFormData { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public async Task<bool> Initialize(string badgeId)
        {
            if (badgeId != null)
            {
                //Make the Api call to get last drink
                var drinkItemData = await WebApiClient.GetAsync<DrinkItemData>(@"Drink/GetLastDrink?badgeId=" + badgeId);
                //Map the drink item data retrieved to form data
                drinkFormData = Mapper.Map<DrinkFormData>(drinkItemData);
            }
            else
            {
                drinkFormData = new DrinkFormData();
            }
            return true;
        }

    }
}