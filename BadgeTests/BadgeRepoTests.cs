using System;
using System.Collections.Generic;
using BadgeConsole;
using BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgeRepo _repo;
        private Badge _badge;
     
 
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge(500,new List<string> { "B1", "Z2" });
            _repo.CreateNewBadge(500, _badge);
        }

        [TestMethod]
        public void CreateNewBadge_ShouldReturnTrue()
        {
            //Arrange

            //Act and Assert
            Assert.IsTrue(_repo.GetBadgeDict().ContainsKey(500));
        }

        [TestMethod]
        public void GetBadgeDict_ShouldReturnNotNull()
        {
            Dictionary<int,Badge> test = _repo.GetBadgeDict();
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void GetBadgeByID_ShouldReturnNotNull()
        {
            Badge answer = _repo.GetBadgeByID(500);
            Assert.IsNotNull(answer);
        }

     
        
    }
}
