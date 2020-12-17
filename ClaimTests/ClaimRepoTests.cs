using System;
using System.Collections.Generic;
using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _claimRepo;
        private Claim _claim;

        [TestInitialize]

        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
            _claim = new Claim((ClaimType)3, "Stolen swag", 4.00m, new DateTime(2018, 12, 30), new DateTime(2019, 01, 31));

            _claimRepo.AddClaimToQueue(_claim);
        }

        [TestMethod]
        public void AddClaimToQueue_ShouldReturnTrue()
        {
            //Arrange
           
            //Act
            _claimRepo.AddClaimToQueue(_claim);
            Claim claimFromDirectory = _claimRepo.GetClaimByID(3);
            //Assert
            Assert.IsTrue(_claimRepo.GetClaimQueue().Contains(_claim)) ;
        }

        [TestMethod]
        public void GetClaimQueue_ShouldGetNotNull()
        {
            //Arrange
          
            //Act
            Queue<Claim> testQueue = _claimRepo.GetClaimQueue();
            //Assert
            Assert.IsNotNull(testQueue);
        }

        [TestMethod]
        public void GetClaimByID_ShouldGetNotNull()
        {
            //Act
            Claim result = _claimRepo.GetClaimByID(3);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void CountMethod_ShouldReturnNotNull()
        {
            //Act
            int count = _claimRepo.CountMethod();
            Assert.IsNotNull(count);
        }

    }
}
