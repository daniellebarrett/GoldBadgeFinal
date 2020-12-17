using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsole
{
    public class ClaimUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedData();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select an option below:\n" +
                    "1. See All Claims:\n" +
                    "2. Take Care Of Next Claim:\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //see all claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        //take care of next claim
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        //enter a new claim
                        CreateNewClaim();
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("\n\n\nGoodbye See Ya Later!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n\n\nPlease select a valid option:");
                        break;
                }
                Console.WriteLine("\n\n\nPlease press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }



        //case 1
        private Queue<Claim> DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimQueue();
            //queue header
            var header = String.Format("{0,-8}{1,-12}{2,-25}{3,18}{4,18:MM/dd/yyyy}{5,18:MM/dd/yyyy}{6,18}",
                "ID", "Type", "Description", "Damage Amount", "Incident Date", "Claim Date", "Valid Claim");
            Console.WriteLine(header);
            foreach (Claim claim in queueOfClaims)
            {
                //format strings here^
                /*Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                  $"Type of Claim: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
              $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
              $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Claim is Valid (T/F): {claim.IsValid}\n");*/




                //0-claimID, 1-TypeOfClaim, 2-Descrp, 3-claimAmnt, 4-doincident 5 doclaim
                Console.WriteLine(String.Format("{0,-8}{1,-12}{2,-25}{3,18}{4,18:MM/dd/yyyy}{5,18:MM/dd/yyyy}{6,18}", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid));


            }
            return queueOfClaims;
        }

        //case2

        private Queue<Claim> TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimQueue();
            //queue header
            var header = String.Format("{0,-8}{1,-12}{2,-25}{3,18}{4,18:MM/dd/yyyy}{5,18:MM/dd/yyyy}{6,18}",
                "ID", "Type", "Description", "Damage Amount", "Incident Date", "Claim Date", "Valid Claim");
            Console.WriteLine(header);
            Claim firstOnList = queueOfClaims.Peek(); //returns but does not delete
            /* queueOfClaims.Dequeue(); returns and deletes*/
            Console.WriteLine(String.Format("{0,-8}{1,-12}{2,-25}{3,18}{4,18:MM/dd/yyyy}{5,18:MM/dd/yyyy}{6,18}", firstOnList.ClaimID, firstOnList.TypeOfClaim, firstOnList.Description, firstOnList.ClaimAmount, firstOnList.DateOfIncident,
                firstOnList.DateOfClaim, firstOnList.IsValid));

            bool checkThis = true;
            while (checkThis)
            {
                Console.WriteLine("\n\n\nDo you want to deal with this claim now?(y/n)");
                string holdThis = Console.ReadLine().ToLower();
                if (holdThis.Contains("n"))
                {
                    checkThis = false;

                }
                else if (holdThis.Contains("y"))
                {
                    checkThis = false;
                    Claim claimToTakeCareOf = queueOfClaims.Dequeue();//holds deleted in a variable?
                }
                else
                {
                    Console.WriteLine("\n\n\nTry following directions");
                    checkThis = true;
                }

            }
            return queueOfClaims;

        }
        //case 3
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            int counter = _claimRepo.CountMethod();
            newClaim.ClaimID = System.Threading.Interlocked.Increment(ref counter);
            /* Console.WriteLine("Enter the Claim ID:");
             string IDAsString = Console.ReadLine();
             newClaim.ClaimID = int.Parse(IDAsString);*/


            Console.WriteLine("Enter claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.TypeOfClaim = (ClaimType)typeAsInt;

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage:");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(amountAsString);

            Console.WriteLine("Date of Accident:");
            string incidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("Date of Claim:");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);

            /* Console.WriteLine("Is this claim valid?(Y/N)");
             string isValid = Console.ReadLine().ToLower();
             if (isValid == "y")
             {
                 newClaim.IsValid = true;
             }
             else
             {
                 newClaim.IsValid = false;
             }*/
            _claimRepo.AddClaimToQueue(newClaim);
        }

        private void SeedData()
        {
            Claim claim1 = new Claim((ClaimType)1, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claim claim2 = new Claim((ClaimType)2, "House fire in kitchen", 40000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claim claim3 = new Claim((ClaimType)3, "Stolen Pancakes", 4.00m, new DateTime(2018, 01, 01), new DateTime(2018, 01, 30));
            Claim claim4 = new Claim((ClaimType)3, "Stolen swag", 4.00m, new DateTime(2018, 12, 30), new DateTime(2019, 01, 31));

            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);
            _claimRepo.AddClaimToQueue(claim4);
        }





    }
}

