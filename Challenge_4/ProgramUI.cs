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
            badge.Door = new List<string>();
            AddDoorsToBadge(badge.Door);

            _badgeRepository.AddBadgeToDictionary(badge);
            ReturnToMenu();
        }

        private void AddDoorsToBadge(List<string> doors)
        {
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
        }

        private void UpdateDoorsToBadge()
        {
            Console.WriteLine("Which key would you like to update access to:");
            DisplayListOfBadges();
            var badgeId = int.Parse(Console.ReadLine());
            AddDoorsToBadge(_badgeRepository.GetBadgeList(badgeId));
            ReturnToMenu();
        }

        private void DeleteDoorsOnBadge()
        {
            Console.WriteLine("Which badge would you like to remove access to:");
            DisplayListOfBadges();
            int response = int.Parse(Console.ReadLine());
            List<string> doors = _badgeRepository.GetBadgeList(response);
            doors.Clear();
            ReturnToMenu();
        }

        private void DisplayBadges()
        {
            Console.WriteLine("Badge # -- Door Access");
            int i = 0;
            foreach (var badge in _badgeRepository.GetBadges())
            {
                i++;
                int key = badge.Key;
                List<string> list = badge.Value;
                Console.Write($"\nKey = {key}  -- Value = ");
                foreach (var d in list)
                {
                    Console.Write($"{d.ToString()}, ");
                }
            }
            ReturnToMenu();
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private void DisplayListOfBadges()
        {
            int i = 0;
            foreach (var badge in _badgeRepository.GetBadges())
            {
                i++;
                int key = badge.Key;
                Console.WriteLine($"#{key}");
            }
        }
    }
}
