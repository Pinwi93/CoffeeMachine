using System;
using Coffee.Service.Interface;
using Coffee.WebAPI.Controllers;
using Entity.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebAPITest
{
    /// <summary>
    /// The Web Api Controller Test
    /// </summary>
    [TestClass]
    public class ControllerTest
    {
        /// <summary>
        /// The service coffee mock
        /// </summary>
        private Mock<IServiceCoffee> ServiceCoffeeMock = new Mock<IServiceCoffee>();

        /// <summary>
        /// Adds the drink success.
        /// </summary>
        [TestMethod]
        public void AddDrink_Success()
        {
            //ARRANGE
            Drink drink = new Drink
            {
                BadgeId = "Se15",
                DrinkType = 0,
                SugarQuantity = 1,
                UseMug = true,
            };
            ServiceCoffeeMock.Setup(service => service.SaveDrink(drink))
            .Returns(drink);
            //ACT
            var controller = new CoffeeController(ServiceCoffeeMock.Object);
            var addeddrink =controller.AddDrink(drink);
            //Assert
            Assert.AreEqual(drink, addeddrink);
        }
        /// <summary>
        /// Gets the last drink get drink.
        /// </summary>
        [TestMethod]
        public void GetLastDrink_GetDrink()
        {
            //ARRANGE
            string badgeId = "Se15";
            Drink drink = new Drink
            {
                DrinkDate=DateTime.Now,
                DrinkId = 1,
                BadgeId = "Se15",
                DrinkType = 0,
                SugarQuantity = 1,
                UseMug = true,
            };
            ServiceCoffeeMock.Setup(service => service.GetLastDrink(badgeId))
            .Returns(drink);
            //ACT
            var controller = new CoffeeController(ServiceCoffeeMock.Object);
            var addeddrink = controller.getLastDrink(badgeId);
            //ASSERT
            Assert.IsNotNull(drink);

        }
        /// <summary>
        /// Gets the last drink return Null.
        /// </summary>
        [TestMethod]
        public void GetLastDrink_ReturnNull()
        {
            //ARRANGE
            string badgeId = "Se15";

            ServiceCoffeeMock.Setup(service => service.GetLastDrink(badgeId))
            .Returns(null as Drink);
            //ACT
            var controller = new CoffeeController(ServiceCoffeeMock.Object);
            var addeddrink = controller.getLastDrink(badgeId);
            //ASSERT
            Assert.IsNull(addeddrink);

        }
    }
}
