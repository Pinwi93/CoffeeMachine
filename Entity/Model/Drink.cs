using Entity.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    /// <summary>
    /// The Drink Class
    /// </summary>
    [Table("Drink")]
    public class Drink
    {
        /// <summary>
        /// Gets or sets the drink identifier.
        /// </summary>
        [Key]
        public int DrinkId { get; set; }

        /// <summary>
        /// Gets or sets the type of the drink.
        /// </summary>
        public DrinkType DrinkType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use mug].
        /// </summary>
        public bool UseMug { get; set; }

        /// <summary>
        /// Gets or sets the sugar quantity.
        /// </summary>
        public int SugarQuantity { get; set; }

        /// <summary>
        /// Gets or sets the badge identifier.
        /// </summary>
        public string BadgeId { get; set; }

        /// <summary>
        /// Gets or sets the drink date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DrinkDate { get; set; }

    }
}
