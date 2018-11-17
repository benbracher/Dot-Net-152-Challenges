using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        public Dictionary<int, List<string>> _dictionaryOfBadges = new Dictionary<int, List<string>>();

        public void AddBadgeToDictionary(Badge badge)
        {
                _dictionaryOfBadges[badge.BadgeID] = badge.Door;
        }

        public List<string> GetBadgeList(int badgeId)
        {
            return _dictionaryOfBadges[badgeId];
        }

        public Dictionary<int, List<string>> GetBadges()
        {
            return _dictionaryOfBadges;
        }
    }
}
