using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }

        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {



            get
            {
                /*TimeSpan daysSince = DateOfClaim - DateOfIncident;
                double daysDouble = daysSince.Days;
                int days = Convert.ToInt32(Math.Floor(daysDouble));
                if (days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }*/

                if (DateOfIncident.AddDays(30) > DateOfClaim)
                {
                    return false;
                }
                else if (DateOfClaim > DateOfIncident)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }



        public Claim() { }

        private static int counter = 0;
        public Claim(ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

            ClaimID = System.Threading.Interlocked.Increment(ref counter);



        }
    }

}
