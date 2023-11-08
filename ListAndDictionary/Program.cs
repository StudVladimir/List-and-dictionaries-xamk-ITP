namespace ListAndDictionary
{
    internal class Program
    {
        // List variable containing names of persons
        private static List<string> personList = new List<string>();

        // Dictionary containing person name and age where the string TKey is for name and the int TValue is for age
        private static Dictionary<string, int> personAgeDictionary = new Dictionary<string, int>();

        public static void Main()
        {
            Console.WriteLine("Welcome to the Person Manager!");
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add New Person");
                Console.WriteLine("2. Remove Person");
                Console.WriteLine("3. Find Person");
                Console.WriteLine("4. List All Persons");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddPerson();
                        option = "";
                        break;
                    case "2":
                        RemovePerson();
                        break;
                    case "3":
                        FindPerson();
                        break;
                    case "4":
                        DisplayAllPersons();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        public static void AddPerson()
        {
            // TODO 1: Request user input for the person's name.
            Console.WriteLine("Write down the person's name: ");
            string name = Console.ReadLine();
            // TODO 2: Validate if the person already exists in the personList.
            foreach (var item in personList)
            {
                if (item == name)
                {
                    Console.WriteLine("Such person already exist in this list");
                    return;
                }
            }
            // TODO 3: Add the person to the personList if they don't already exist.
            personList.Add(name);
            // TODO 4: Provide user feedback for successful addition or if the person already exists in personList.
            foreach (var item in personList)
            {
                if (item == name)
                    Console.WriteLine($"Successful add {name} in list");
            }
            // TODO 5: Validate if the person already exists in the personAgeDictionary.
            if (personAgeDictionary.ContainsKey(name))
            {
                Console.WriteLine("Such person already exist in dicitionary");
            }
            // TODO 6: If they don't exist, request age input and add the person to the personAgeDictionary.
            //         NOTE!: Remember to add both TKey and TValue
            Console.WriteLine("Input the age of the person: ");
            int age = int.Parse(Console.ReadLine());
            personAgeDictionary.Add(name, age);
            // TODO 7: Provide user feedback for successful addition or if the person already exists in personAgeDictionary.
            if (personAgeDictionary.ContainsKey(name)&& personAgeDictionary.ContainsValue(age))
                Console.WriteLine("Person was successfuly added in dictionary");
        }

        public static void RemovePerson()
        {
            // TODO 8: Request user input for the name of the person to remove.
            Console.WriteLine("Input the name of person wich one you want to remove: ");
            string name = Console.ReadLine();
            // TODO 9: Remove the person from personList if they exist.
            foreach (var item in personList)
            {
                if (item == name)
                {
                    personList.Remove(name);
                    Console.WriteLine($"You delete {name} from the list");
                    break;
                }
                Console.WriteLine($"Can't find person with name: {name}");
            }
            // TODO 10: Provide user feedback for successful removal or if the person doesn't exist in personList.
            // TODO 11: Remove the person from personAgeDictionary if they exist.
            if (personAgeDictionary.ContainsKey(name))
            {
                personAgeDictionary.Remove(name);
                Console.WriteLine($"You delete {name} from the dictionary");
            }
            // TODO 12: Provide user feedback for successful removal or if the person doesn't exist in personAgeDictionary.
        }

        public static void FindPerson()
        {
            // TODO 13: Request user input for the name of the person to find.
            Console.WriteLine("Input the name of person: ");
            string name = Console.ReadLine();
            // TODO 14: Check if the person is in personList and provide appropriate feedback.
            foreach (var item in personList)
            {
                if (item == name)
                {
                    Console.WriteLine($"The person {name} is in the list");
                }
                else
                {
                    Console.WriteLine($"Can't find person with name: {name} in the list");
                }
                
            }
            // TODO 15: Check if the person is in personAgeDictionary and provide appropriate feedback.
            if (personAgeDictionary.ContainsKey(name))
                Console.WriteLine($"The person {name} is in the dictionary");
            else
                Console.WriteLine($"Can't find person with name: {name} in the dictionary");
        }

        public static void DisplayAllPersons()
        {
            // TODO 16: Iterate over personList and display each person's name.
            if (personList.Count > 0)
            {
                Console.WriteLine("LIST");
                foreach (var item in personList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("The list is empty");
            }
            
            // TODO 17: Iterate over personAgeDictionary and display each person's name and age.
            if (personAgeDictionary.Count > 0)
            {
                Console.WriteLine("DICTIONARY");
                for (int i = 0; i < personAgeDictionary.Count; i++)
                {
                    Console.WriteLine(personAgeDictionary.ElementAt(i).Key+" "+ personAgeDictionary.ElementAt(i).Value);
                }
            }
            else
            {
                Console.WriteLine("The dictionary is empty");
            }
            // TODO 18: Consider handling the case where the lists are empty by providing feedback to the user.
        }
    }
}
