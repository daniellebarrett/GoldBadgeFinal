using BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{

    public class BadgeUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        private int _nextID = 1;
        public void Run()
        {
            SeedMethod();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Add a badge
                        CreateNewBadge();
                        break;
                    case "2":
                        //Edit a badge
                        EditBadge();
                        break;
                    case "3":
                        //list all badges
                        DisplayAllBadges();
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("See ya later alligator");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
                Console.WriteLine("\n\n\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add a badge
        private void CreateNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            newBadge.BadgeID = GenerateIDNumber();
            bool keepAdding = true;
            while (keepAdding)
            {
                Console.WriteLine("Badge ID Numbers are automatically generated");
                Console.WriteLine("List a door that this badge needs access to (one at a time):");
                string door = Console.ReadLine();
                newBadge.DoorNames.Add(door);
                bool doorInput = true;
                while (doorInput)
                {
                    Console.WriteLine("Would you like to give this badge access to another door?(Y/N)");
                    string access = Console.ReadLine().ToLower();
                    if (access.Contains("n"))
                    {
                        keepAdding = false;
                        doorInput = false;
                    }
                    else if (access.Contains("y"))
                    {
                        keepAdding = true;
                        doorInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Error. Try typing Y or N");
                        doorInput = true;
                    }
                }

            }
            _badgeRepo.CreateNewBadge(newBadge.BadgeID, newBadge);
        }
        //Edit a badge
        private void EditBadge()
        {
            DisplayAllBadges();

            Console.WriteLine("Enter the badge ID for the badge you would like to edit:");
            string badgeIDAsString = Console.ReadLine();

            int badgeIDAsInt = int.Parse(badgeIDAsString);
            Badge editedBadge = _badgeRepo.GetBadgeByID(badgeIDAsInt);
           

            Console.WriteLine("Select an option:\n" +
                "1. Add A Door(one at a time)\n" +
                "2. Remove A Door(one at a time)");
            Console.ReadLine();
            Console.Clear();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddDoor(editedBadge);
                    break;
                case "2":
                    RemoveDoor(editedBadge);
                    break;
            }
        }

        //List all badges
        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> dictionaryOfBadges = _badgeRepo.GetBadgeDict();

            foreach (KeyValuePair<int, Badge> dict in dictionaryOfBadges)
            {
                Console.WriteLine($"\nBadge ID: {dict.Key}");

                foreach (string doorName in dict.Value.DoorNames)
                {
                    Console.WriteLine($"Door: {doorName}");
                }
            }

        }

        public void AddDoor(Badge editedBadge)
        {
            bool keepAdding = true;
            while (keepAdding)
            {
                Console.WriteLine("Enter the door name you would like to add:");
                string doorInput = Console.ReadLine();
                if (!editedBadge.DoorNames.Contains(doorInput))
                {
                    editedBadge.AddDoorToBadge(doorInput);
                    Console.WriteLine("Door added successfully!");
                }
                else
                {
                    Console.WriteLine("This badge already has access to this door");
                }
                bool addAgain = true;
                while (addAgain)
                {
                    Console.WriteLine("Would you like to add another door?(Y/N)");
                    string anotherAdd = Console.ReadLine().ToLower();
                    if (anotherAdd == "n")
                    {
                        keepAdding = false;
                        addAgain = false;
                    }
                    else if (anotherAdd == "y")
                    {
                        keepAdding = true;
                        addAgain = false;
                    }
                    else
                    {
                        Console.WriteLine("Error. Try typing Y or N");
                        addAgain = true;
                    }
                }
            }

        }
        public void RemoveDoor(Badge editedBadge) 
        {
            bool keepDeleting = true;
            while (keepDeleting)
            {
                Console.WriteLine("Enter the door name you would like to remove:");
                string answer = Console.ReadLine();
                if (!editedBadge.DoorNames.Contains(answer))
                {
                    Console.WriteLine("You can't remove a door that doesn't exist");
                }
                else
                {
                    editedBadge.RemoveDoorFromBadge(answer);
                    Console.WriteLine("Door removed!");
                }
                bool removeAgain = true;
                while (removeAgain)
                {
                    Console.WriteLine("Would you like to remove another door?(Y/N)");
                    string anotherInput = Console.ReadLine().ToLower();
                    if (anotherInput == "n")
                    {
                        keepDeleting = false;
                        removeAgain = false;
                    }
                    else if (anotherInput == "y")
                    {
                        keepDeleting = true;
                        removeAgain = false;
                    }
                    else
                    {
                        Console.WriteLine("Error. Try typing Y or N");
                        removeAgain = true;
                    }
                }

            }
        }

        private int GenerateIDNumber()
        {
            int id = _nextID;
            _nextID++;
            return id;
        }
        private void SeedMethod()
        {
            Badge badge1 = new Badge(GenerateIDNumber(), new List<string> { "A1", "A2" });
            Badge badge2 = new Badge(GenerateIDNumber(), new List<string> { "U7", "H3" });
            Badge badge3 = new Badge(GenerateIDNumber(), new List<string> { "B1", "Z2" });

            _badgeRepo.CreateNewBadge(badge1.BadgeID, badge1);
            _badgeRepo.CreateNewBadge(badge2.BadgeID, badge2);
            _badgeRepo.CreateNewBadge(badge3.BadgeID, badge3);
        }
    }
}

