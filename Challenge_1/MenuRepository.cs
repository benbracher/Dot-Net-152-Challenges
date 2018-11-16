using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class MenuRepository
    {
        public List<Menu> _listOfMenuItems = new List<Menu>();

        public void AddItemToMenu(Menu item)
        {
            _listOfMenuItems.Add(item);
        }

        public List<Menu> GetMenuList()
        {
            return _listOfMenuItems;
        }

        public void DeleteMenuItem(Menu item)
        {
            _listOfMenuItems.Remove(item);
        }
    }
}
