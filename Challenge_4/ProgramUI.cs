using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class ProgramUI
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

            _badgeRepository.AddBadgeToDictionary(badge);
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
            Badge badge = new Badge();
            Console.WriteLine("Which key would you like to update access to:");
            DisplayListOfBadges();
            badge.BadgeID = int.Parse(Console.ReadLine());
            AddDoorsToBadge();
            _badgeRepository.AddBadgeToDictionary(badge);
            ReturnToMenu();
        }

        private void DeleteDoorsOnBadge()
        {
            Console.WriteLine("Which badge would you like to remove access to:");
            DisplayListOfBadges();
            int response = int.Parse(Console.ReadLine());
            _badgeRepository.GetBadgeList()[response] = new List<string>();
            ReturnToMenu();
        }

        private void DisplayBadges()
        {
            Console.WriteLine("Badge # -- Door Access");
            int i = 0;
            foreach (var badge in _badgeRepository.GetBadgeList())
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
            foreach (var badge in _badgeRepository.GetBadgeList())
            {
                i++;
                int key = badge.Key;
                Console.WriteLine($"#{key}");
            }
        }
    }
}
