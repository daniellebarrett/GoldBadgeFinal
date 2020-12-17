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
        {       //contains key go here?

            _badgeDictionary.Add(badgeKey, badge);
        }
        //Read
        public Dictionary<int, Badge> GetBadgeDict()
        {
            return _badgeDictionary;
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

