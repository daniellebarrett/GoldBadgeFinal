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
        public List<string> DoorNames { get; set; }

        public Badge() { }

        private static int counter = 0;
        public Badge(int badgeID, List<string> doorNames)
        {
            DoorNames = doorNames;
            BadgeID = System.Threading.Interlocked.Increment(ref counter);
        }
    }
}

