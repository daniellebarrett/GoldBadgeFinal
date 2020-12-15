using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class BadgeRepo
    {
        private Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        //create a dictionary of badges

        //Create
        public void CreateNewBadge(int badgeKey, Badge badge)

        // need to see if key exists b4 trying to use it. set variable?
        {
            _badgeDictionary.Add(badge.BadgeID, badge);
        }
        //Read
        public Dictionary<int, Badge> GetMenuBadgeDict()
        {
            return _badgeDictionary;
        }
        //Update
        public bool UpdateBadge(int badgeID, Badge badge)
        {
            Badge oldBadge = GetBadgeByID(badgeID);
            if (oldBadge != null)
            {
                oldBadge.DoorNames = badge.DoorNames;
                return true;
            }
            return false;
        }
        //Delete
        public bool RemoveBadgeFromDictionary(int badgeID)
        {
            if (_badgeDictionary.Remove(badgeID))
            {
                return true;
            }
            return false;
        }

        public Badge GetBadgeByID(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> badge in _badgeDictionary)
            {
                int key = badge.Key;
                Badge value = badge.Value;

                if (key == badgeID)
                {
                    return value;
                }
            }
            return null;
        }
    }
}

