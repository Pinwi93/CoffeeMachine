using AutoMapper;
using CoffeeService.Front.Models.FormData;
using CoffeeService.Front.Models.ItemData;
using Entity.Model;

namespace CoffeeService.Front.App_Start
{
    /// <summary>
    /// The Auto Mapper Config
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        public static void Run()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DrinkFormData, DrinkItemData>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<Drink, DrinkFormData>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
        }
    }
}