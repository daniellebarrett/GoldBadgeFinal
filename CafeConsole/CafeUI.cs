using CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole
{
    class CafeUI
    {
        private CafeRepo _CafeRepo = new CafeRepo();

        public void Run()
        {
            SeedMethod();
            Cafe();
        }


        private void Cafe()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select a Cafe item:\n" +
                    "1. Create New Cafe Item\n" +
                    "2. View All Cafe Items\n" +
                    "3. View Cafe Item By Item Number\n" +
                    "4. Delete Existing Cafe Item\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewCafeItem();
                        break;
                    case "2":
                        DisplayAllCafeItems();
                        break;
                    case "3":
                        DisplayItemByNumber();
                        break;
                    case "4":
                        DeleteExistingItem();
                        break;
                    case "5":
                        Console.WriteLine("Have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid item number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //create new Cafe item
        private void CreateNewCafeItem()
        {
            Console.Clear();
            Cafe newItem = new Cafe();

            //item number
            Console.WriteLine("Enter the item number for the Cafe item:");
            string itemNumaSString = Console.ReadLine();
            newItem.ItemNumber = int.Parse(itemNumaSString);
            //name
            Console.WriteLine("Enter the name of the new Cafe item:");
            newItem.Name = Console.ReadLine();
            //description
            Console.WriteLine("Enter the description of the new Cafe item:");
            newItem.Description = Console.ReadLine();
            //ingredients
            newItem.listOfIngredients = new List<string>();

            bool keepAdding = true;
            while (keepAdding)
            {
                Console.WriteLine("Enter ingredients (one at a time):");
                string ingredient = Console.ReadLine();
                if (!newItem.listOfIngredients.Contains(ingredient))
                {
                    newItem.listOfIngredients.Add(ingredient);

                }
                else
                {
                    Console.WriteLine("You've already added this ingredient to this Cafe item");
                }

                bool validInput = true;
                while (validInput)
                {
                    Console.WriteLine("Would you like to add another ingredient? (Y/N)");
                    string banana = Console.ReadLine().ToLower();
                    if (banana.Contains("n"))
                    {
                        keepAdding = false;
                        validInput = false;
                    }
                    else if (banana.Contains("y"))
                    {
                        keepAdding = true;
                        validInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Error. Try typing Y or N");
                        validInput = true;
                    }
                }
            }

            //price
            Console.WriteLine("Enter the price of the new Cafe item:");
            decimal input = decimal.Parse(Console.ReadLine());
            newItem.Price = input;

            _CafeRepo.AddItemToCafe(newItem);
        }

        private List<Cafe> DisplayAllCafeItems()
        {
            Console.Clear();
            List<Cafe> listOfCafeItems = _CafeRepo.GetCafeItemList();

            foreach (Cafe item in listOfCafeItems)
            {
                Console.WriteLine($"#: {item.ItemNumber}\n" +
                    $"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Price: ${item.Price}\n" +
                $"Ingredients:");

                foreach (string ingredient in item.listOfIngredients)
                {
                    Console.WriteLine(ingredient);
                }

            }
            return listOfCafeItems;
        }

        private void DisplayItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the item number for the Cafe item you would like to see:");
            int input = int.Parse(Console.ReadLine());
            Cafe itemNum = _CafeRepo.GetItemByNumber(input);

            if (itemNum != null)
            {
                Console.WriteLine($"#: {itemNum.ItemNumber}\n" +
                    $"Name: {itemNum.Name}\n" +
                    $"Description: {itemNum.Description}\n" +
                    $"Ingredients: {itemNum.listOfIngredients}\n" +
                    $"Price: {itemNum.Price}");
            }
            else
            {
                Console.WriteLine("Sorry could not find a Cafe item associated with that Cafe #.");
            }
        }
        private void DeleteExistingItem()
        {
            DisplayAllCafeItems();
            Console.WriteLine("Enter the Cafe item # of the Cafe item you would like to remove:");
            int input = int.Parse(Console.ReadLine());

            bool wasRemoved = _CafeRepo.RemoveItemFromCafe(input);
            if (wasRemoved)
            {
                Console.WriteLine("The Cafe item was succesfully removed!");
            }
            else
            {
                Console.WriteLine("Sorry - could not remove Cafe item!");
            }
        }
        private void SeedMethod()
        {
            Cafe item1 = new Cafe(1, "Happy Burger", "Made from real beef and pure happiness", new List<string> { "Beef", "American cheese", "pickle", "ketchup" }, 2.50m);
            Cafe item2 = new Cafe(2, "Tilly's House Salad", "House favorite made with homegrown ingredients", new List<string> { "shredded iceburg lettuce", "tomatoes", "red onion", "croutons" }, 3.00m);
            Cafe item3 = new Cafe(3, "Jack's Chicken", "Jack Daniel's chicken you cannot miss", new List<string> { "chicken", "bbq", "onion" }, 7.50m);

            _CafeRepo.AddItemToCafe(item1);
            _CafeRepo.AddItemToCafe(item2);
            _CafeRepo.AddItemToCafe(item3);
        }
    }
}
