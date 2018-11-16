using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        public List<Outing> _listOfOutings = new List<Outing>();

        public void AddOutingToList(Outing outing)
        {
            _listOfOutings.Add(outing);
        }

        public List<Outing> GetOutingsList()
        {
            return _listOfOutings;
        }

        public decimal SortAndTotalCostByType(string response)
        {
            var cost = 0.0m;
            var outingsByType = _listOfOutings.FindAll(l => l.EventType == response);
            foreach (var outing in outingsByType)
            {
                cost = cost + outing.EventCost;
            }
            return cost;
        }

        public decimal TotalOutingListCost()
        {
            var totalCost = 0.0m;
            foreach (var outing in _listOfOutings)
            {
                totalCost += outing.EventCost;
            }
            return totalCost;
        }


        //public List<Outing> GetOutingsByType(string type)
        //{
        //    var outingsByType = new List<Outing>();

        //    foreach(var outing in _listOfOutings)
        //    {
        //        if(outing.EventType == type)
        //        {
        //            outingsByType.Add(outing);
        //        }
        //    }

        //    return outingsByType;
        //}
    }
}
