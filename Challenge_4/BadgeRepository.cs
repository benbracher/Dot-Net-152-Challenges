using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class BadgeRepository
    {
        public Dictionary<int, List<string>> _dictionaryOfBadges = new Dictionary<int, List<string>>();

        public void AddBadgeToDictionary(Badge badge)
        {
            _dictionaryOfBadges.Add(badge.BadgeID, badge.Door);
        }

        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _dictionaryOfBadges;
        }
    }
}
