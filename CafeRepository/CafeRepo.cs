using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class CafeRepo
    {
        
        //make a field to use it in all of your crum methods
       private readonly List<Cafe> _listOfCafeItems = new List<Cafe>();

        //CRUD METHODS HELD HERE
        //Create
        public void AddItemToCafe(Cafe item)
        {
            _listOfCafeItems.Add(item);
        }
        //Read
        public List<Cafe> GetCafeItemList()
        {
            return _listOfCafeItems;
        }

        //Update
        //note says we don't need to update right now??

        //Delete
        public bool RemoveItemFromCafe(int itemNum)
        {
            Cafe item = GetItemByNumber(itemNum);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listOfCafeItems.Count;
            _listOfCafeItems.Remove(item);

            if (initialCount > _listOfCafeItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method - gets the correct item based on the item number

        public Cafe GetItemByNumber(int itemNum)
        {
            foreach (Cafe item in _listOfCafeItems)
            {
                if (item.ItemNumber == itemNum)
                {
                    return item;
                }
            }

            return null;
        }
    }
}

