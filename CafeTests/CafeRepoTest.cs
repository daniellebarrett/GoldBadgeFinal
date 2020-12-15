using System;
using System.Collections.Generic;
using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class CafeRepoTest
    {
        private CafeRepo _repo;
        private Cafe _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepo();
            _item = new Cafe(9, "Chicken Tenders", "Best Kid's Meal In House", new List<string> { "Chicken tenders", "your choice of potato", "your choice of dipping sauce" }, 5.00m);

            _repo.AddItemToCafe(_item);
        }

        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            //Arrange
            Cafe item = new Cafe();
            item.ItemNumber = 1;
            CafeRepo repo = new CafeRepo();
            //Act
            repo.AddItemToCafe(item);
            Cafe itemFromDirectory = _repo.GetItemByNumber(9);
            //Assert
            Assert.IsTrue(repo.GetCafeItemList().Contains(item));
        }

        [TestMethod]
        public void GetItem_ShouldGetNotNull()
        {
            //Arrange
            List<string> listofIngredients = new List<string>();
            listofIngredients.Add("ingredientTest");
            CafeRepo repo = new CafeRepo();
            //Act
            List<Cafe> testList = repo.GetCafeItemList();
            //Assert
            Assert.IsNotNull(testList);
        }

        [TestMethod]
        public void RemoveItem_ShouldReturnTrue()
        {
            //Arrange
            Cafe item = new Cafe();
            item.ItemNumber = 321;
            CafeRepo repo = new CafeRepo();
            //Act
            bool removeItem = _repo.RemoveItemFromCafe(_item.ItemNumber);
            //Assert
            Assert.IsTrue(removeItem);
        }
    }
}

