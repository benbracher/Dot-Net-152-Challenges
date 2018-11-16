using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class Menu
    {
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public int MealPrice { get; set; }
        public List<string> MealIngredients { get; set; }

        public Menu(string mealName, string mealDescription, int mealPrice,  List<string> mealIngredients)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            MealIngredients = mealIngredients;
        }

        public Menu()
        {

        }
    }
}
