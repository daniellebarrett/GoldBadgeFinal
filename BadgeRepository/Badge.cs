using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class Badge
    {
        
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badge() { }

        public Badge(int badgeID, List<string> doorNames)
        {
            DoorNames = doorNames;
            BadgeID = badgeID;
        }

        public void AddDoorToBadge(string door)
        {
            DoorNames.Add(door);
        }

        public void RemoveDoorFromBadge(string door)
        {
            DoorNames.Remove(door); 
        }
    }
}

