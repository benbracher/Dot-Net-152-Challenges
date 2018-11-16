using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class ProgramUI
    {
        BadgeRepository _badgeRepository = new BadgeRepository();

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
                Console.WriteLine("Komodo Insurance\n" +
                    "1. Create a new badge\n" +
                    "2. Update doors on a badge\n" +
                    "3. Delete doors on a badge\n" +
                    "4. Display all badges\n" +
                    "5. Exit application");

                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        CreateBadge();
                        break;
                    case 2:
                        UpdateDoorsToBadge();
                        break;
                    case 3:
                        DeleteDoorsOnBadge();
                        break;
                    case 4:
                        DisplayBadges();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry...");
                        break;
                }
            }
        }

        private void CreateBadge()
        {
            Badge badge = new Badge();
            List<string> doors = new List<string>();
            Console.WriteLine("Enter badge ID #:");
            badge.BadgeID = int.Parse(Console.ReadLine());
            badge.Door = AddDoorsToBadge();
            ReturnToMenu();
        }

        private List<string> AddDoorsToBadge()
        {
            var doors = new List<string>();
            Console.WriteLine("Would you like to add a door(y/n)");
            var response = Console.ReadLine();
            while (response == "y")
            {
                Console.WriteLine("Add door:");
                var door = Console.ReadLine();
                doors.Add(door);

                Console.WriteLine("Would you like to add another door(y/n):");
                response = Console.ReadLine();
            }
            return doors;
        }

        private void UpdateDoorsToBadge()
        {
            ReturnToMenu();
        }

        private void DeleteDoorsOnBadge()
        {
            ReturnToMenu();
        }

        private void DisplayBadges()
        {
            Console.WriteLine("Badge # -- Door Access");
            int i = 0;
            foreach (Badge badge in _badgeRepository.GetBadgeList())
            {
                i++;
                Console.WriteLine($"{badge.BadgeID} -- {badge.Door}");
            }
            ReturnToMenu();
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
