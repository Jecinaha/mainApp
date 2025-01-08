using System.Security.Cryptography.X509Certificates;
using mainApp.Factories;
using mainApp.Models;

namespace mainApp.Services
{
    public class MenuService : IMenuService
    {
        private readonly PersonService _personService = new();
        public void ShowMainMenu()
        {
            while (true)
            {
                var option = MainMenu();
                if (!string.IsNullOrEmpty(option))
                {
                    MenuOptionSelector(option);
                }
                else
                {
                    Console.WriteLine("You must enter a valid option");
                    Console.ReadKey();
                }
            }
        }
        public static string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("----------MAIN MENU------------");
            Console.WriteLine($"{"1.",-5} Create");
            Console.WriteLine($"{"2.",-5} Wiew");
            Console.WriteLine($"{"3.",-5} Download");
            Console.WriteLine($"{"4.",-5} Quit Application");
            Console.WriteLine("----------------------");
            Console.Write("Choose your option: ");
            var option = Console.ReadLine()!;

            return option;
        }

        public void MenuOptionSelector(string option)
        {
            switch (option)
            {
                case "1":
                    CreatePersons();
                    break;
                case "2":
                    WiewAllPersons();
                    break;
                case "3":
                    SaveAllPersons();
                    break;
                case "4":
                    QuitOption();
                    break;
                default:
                    InvalidOption();
                    break;
            }
        }

        public void CreatePersons()
        {
            Console.Clear();


            var personRegistrationForm = PersonFactory.Create();


            Console.Write("Enter your first name: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            Console.Write("Enter your last name: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            Console.Write("Enter your email: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            Console.Write("Enter your phone number: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            Console.Write("Enter your street address: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            Console.Write("Enter your post number: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            Console.Write("Enter the town you live in: ");
            personRegistrationForm.FirstName = Console.ReadLine()!;

            bool result = _personService.Create(personRegistrationForm);
            
            if (result)
            {
                OutputDialog("Person was created successfully");
            }
            else
            {
                OutputDialog("Person was not created");
            }

        }

        public void WiewAllPersons()
        {
            var persons = _personService.GetAll();

            Console.Clear();

            foreach (var person in persons)
            {
                Console.WriteLine("********** Wiew all persons **********\n");
                Console.WriteLine($"{"´Name:",-5}{person.FirstName} {person.LastName}");
                Console.WriteLine($"{"Email:",-5}{person.Email}");
                Console.WriteLine($"{"Street address:",-5}{person.StreetAddress}");
                Console.WriteLine($"{"Phone number:",-5}{person.PhoneNumber}");
                Console.WriteLine($"{"Post code:",-5}{person.PostCode}");
                Console.WriteLine($"{"Town:",-5}{person.Town}");
            }
            Console.ReadKey();
        }

        public static void SaveAllPersons()
        {
            Console.Clear();
            Console.ReadKey();
        }
        public static void QuitOption()
        {
            Console.Clear();
            Console.WriteLine("Do You wanna quit this application (y/n): ");
            var option = Console.ReadLine()!;

            if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

        public static void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("You must enter a valid option");
            Console.ReadKey();
        }

        public static void OutputDialog(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }


    }
}
