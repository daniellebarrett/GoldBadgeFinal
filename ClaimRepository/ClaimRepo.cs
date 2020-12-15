using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimRepo
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();

        public void AddClaimToQueue(Claim claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        public Queue<Claim> GetClaimQueue()
        {
            return _queueOfClaims;
        }

        public bool UpdateExistingClaim(int originalClaim, Claim newClaim)
        {
            Claim oldClaim = GetClaimByID(originalClaim);

            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                return true;
            }
            return false;
        }
        public bool RemoveClaimFromQueue()
        {
            ////note to self: return to this when generating unqiue IDs .Count()
            int countPreRemoval = _queueOfClaims.Count(); //tells count of claims
            _queueOfClaims.Dequeue(); //remove the claim from top of list

            bool correctCount;
            if (countPreRemoval > _queueOfClaims.Count())   //-----if (countPreRemoval == (_queueOfClaims.Count() +1)
            {
                correctCount = true;
                return correctCount;
            }
            else
            {
                return false;
            }


        }
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claim in _queueOfClaims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }

        public int CountMethod()
        {
            return _queueOfClaims.Count();
        }

    }
}

