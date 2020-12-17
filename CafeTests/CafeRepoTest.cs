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
        public void AddToCafe_ShouldGetNotNull()
        {
            //Arrange
            
            //Act
            _repo.AddItemToCafe(_item);
            Cafe itemFromDirectory = _repo.GetItemByNumber(9);
            //Assert
            Assert.IsTrue(_repo.GetCafeItemList().Contains(itemFromDirectory));
        }

        [TestMethod]
        public void GetCafeItemList_ShouldGetNotNull()
        {
            //Arrange
            
            //Act
            List<Cafe> testList = _repo.GetCafeItemList();
            //Assert
            Assert.IsNotNull(testList);
        }

        [TestMethod]
        public void RemoveItem_ShouldReturnTrue()
        {
            //Arrange
            
            //Act
            bool removeItem = _repo.RemoveItemFromCafe(9);
            //Assert
            Assert.IsTrue(removeItem);
        }
    }
}

