using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class ProgramUI
    {
        ClaimRepository _claimRepository = new ClaimRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Claims Department\n" +
                    "Please choose an option:\n" +
                    "\t1. See all claims\n" +
                    "\t2. Take care of next claim\n" +
                    "\t3.Enter a new claim\n" +
                    "\t4.Exit application");

                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        DisplayClaimQueue();
                        break;
                    case 2:
                        QueueClaim();
                        break;
                    case 3:
                        CreateClaim();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void DisplayClaimQueue()
        {
            Console.WriteLine($"\n{"ClaimId", -7} {"Type", -7} {"Description", -20} {"Amount", -12} {"DateOfAccident", -15} {"DateOfClaim", -15} {"IsValid"}");
            int i = 0;
            foreach (Claim claim in _claimRepository.GetClaimsQueue())
            {
                i++;
                Console.WriteLine($"{claim.ClaimId, -7} {claim.ClaimType, -7} {claim.Description, -20} {claim.ClaimAmount, -12:C} {claim.DateOfIncident.ToShortDateString(), -15} {claim.DateOfClaim.ToShortDateString(), -15} {claim.IsValid}");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private void QueueClaim()
        {
            Queue<Claim> claimQueue = _claimRepository.GetClaimsQueue();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine($"ClaimID: {claimQueue.Peek().ClaimId}\n" +
                $"Type: {claimQueue.Peek().ClaimType}\n" +
                $"Description: {claimQueue.Peek().Description}\n" +
                $"Amount: {claimQueue.Peek().ClaimAmount}\n" +
                $"DateOfAccident: {claimQueue.Peek().DateOfIncident.ToShortDateString()}\n" +
                $"DateOfClaim: {claimQueue.Peek().DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {claimQueue.Peek().IsValid}");
            Console.WriteLine("Do you want to deal with this claim now(y/n):");
            string response = Console.ReadLine();
            if (response == "y")
            {
                claimQueue.Dequeue();
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }

        private void CreateClaim()
        {
            Claim claim = new Claim();
            Console.WriteLine("Enter the claim ID:");
            claim.ClaimId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the type of claim(Car, House, Theft):");
            claim.ClaimType = Console.ReadLine();
            Console.WriteLine("Describe the claim:");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Enter the claim amount:");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date of accident(DD/MM/YYYY):");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date of claim(DD/MM/YYYY):");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            if ((claim.DateOfClaim - claim.DateOfIncident).Days <= 30)
            {
                claim.IsValid = true;
            }

            _claimRepository.AddItemToClaim(claim);
            Console.Clear();
        }

        public string PrintClaims(Queue<string> claims)
        {
            string printedClaims = "";
            foreach (var claim in claims)
            {
                printedClaims = claim + $"{0,-7}" + printedClaims;
            }
            return printedClaims;
        }
    }
}
