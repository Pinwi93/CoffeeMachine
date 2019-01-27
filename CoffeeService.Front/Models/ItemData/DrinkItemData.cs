using CoffeeService.Front.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeService.Front.Models.ItemData
{
    /// <summary>
    /// The Drink ItemData
    /// </summary>
    public class DrinkItemData
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public int DrinkId { get; set; }

        /// <summary>
        /// Gets or sets the sugar quantity.
        /// </summary>
        [Display(Name = "Sugar Quantity")]
        public int SugarQuantity { get; set; }

        /// <summary>
        /// Gets or sets the type of the drink.
        /// </summary>
        [Display(Name = "Drink Type")]
        public DrinkType DrinkType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use mug].
        /// </summary>
        [Display(Name = "Use Mug")]
        public bool UseMug { get; set; }

        /// <summary>
        /// Gets or sets the badge identifier.
        /// </summary>
        [Display(Name = "Badge")]
        public string BadgeId { get; set; }

        /// <summary>
        /// Gets or sets the drink date.
        /// </summary>
        public DateTime DrinkDate { get; set; }
    }
}