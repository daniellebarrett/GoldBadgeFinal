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
            Claim claim = new Claim();
            claim.ClaimID = 1;
            ClaimRepo repo = new ClaimRepo();
            //Act
            repo.AddClaimToQueue(claim);
            Claim claimFromDirectory = _claimRepo.GetClaimByID(2);
            //Assert
            Assert.IsTrue(repo.GetClaimQueue().Contains(claim));
        }

        [TestMethod]
        public void GetClaimQueue_ShouldGetNotNull()
        {
            //Arrange
            // Claim claim = new Claim();
            /* Queue<Claim> queueOfClaims = new Queue<Claim>();
             queueOfClaims.Enqueue(claim);*/
            ClaimRepo repo = new ClaimRepo();
            //Act
            Queue<Claim> testQueue = repo.GetClaimQueue();
            //Assert
            Assert.IsNotNull(testQueue);
        }


    }
}
