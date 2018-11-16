using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class ProgramUI
    {
        MenuRepository _menuRepository = new MenuRepository();
        public List<Menu> _listOfMenuItems = new List<Menu>();
        

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe\n" +
                    "Please choose an option:\n" +
                    "\t1.Create a menu item\n" +
                    "\t2.Delete a menu item\n" +
                    "\t3.Display full menu\n" +
                    "\t4.Exit application");

                int menuInput = int.Parse(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        DeleteMenuItem();
                        break;
                    case 3:
                        DisplayMenuList();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid reponse");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void DisplayMenuList()
        {
            Console.WriteLine("Komodo Cafe Menu:");
            int i = 0;
            foreach (Menu menu in _menuRepository.GetMenuList())
            {
                i++;
                Console.WriteLine($"\t{i}. {menu.MealName}:" +
                    $"\n\tDescription: {menu.MealDescription} " +
                    $"\n\tPrice: ${menu.MealPrice}" +
                    $"\n\tIngredients: {PrintIngredients(menu.MealIngredients)}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void DeleteMenuItem()
        {
            int i = 0;
            Console.WriteLine("Komodo Cafe Menu:");
            foreach (Menu menu in _menuRepository.GetMenuList())
            {
                i++;
                Console.WriteLine($"\t{i}: {menu.MealName}");
            }
            Console.WriteLine("Enter the number of the item you want to remove...");
            int removeReponse = int.Parse(Console.ReadLine());
            _menuRepository.GetMenuList().RemoveAt(removeReponse - 1);
            Console.Clear();

        }

        private void CreateMenuItem()
        {
            Menu menu = new Menu();
            Console.WriteLine("Enter meal name:");
            menu.MealName = Console.ReadLine();
            Console.WriteLine("Enter meal description:");
            menu.MealDescription = Console.ReadLine();
            menu.MealIngredients = AddIngredients();
            Console.WriteLine("Set price of meal:");
            menu.MealPrice = int.Parse(Console.ReadLine());

            _menuRepository.AddItemToMenu(menu);
            Console.Clear();
        }

        private List<string> AddIngredients()
        {
            var ingredients = new List<string>();
            Console.WriteLine("Would you like to add ingredients?(y/n)");
            var response = Console.ReadLine();
            while (response == "y")
            {
                Console.WriteLine("Add ingredient:");
                var ingredient = Console.ReadLine();
                ingredients.Add(ingredient);

                Console.WriteLine("Would you like to add another ingredient?(y/n)");
                response = Console.ReadLine();
            }
            return ingredients;
        }

        public string PrintIngredients(List<string> ingredients)
        {
            string printedIngredients = "";
            foreach (var ingredient in ingredients)
            {
                printedIngredients = ingredient + ", " + printedIngredients;
            }
            return printedIngredients;
        }
    }
}
