

using mainApp.Factories;
using mainApp.Models;

namespace mainApp.Services
{
    public class MenuService
    {
        private readonly PersonService _personService = new();

        public void ShowMenu()
        {
            while(true)
            {
                MainMenu();
            }
        }
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"{"1.",-5} Create");
            Console.WriteLine($"{"2.",-5} Wiew");
            Console.WriteLine($"{"3.",-5} Download");
            Console.WriteLine($"{"4.",-5} Quit Application");
            Console.WriteLine("----------------------");
            Console.Write("Choose your option: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    CreateOption();
                    break;

                case "2":
                    WieWOption();
                    break;

                case "3":
                    DownloadOption();
                    break;

                case "4":
                    QuitOption();
                    break;

                default:
                    InvalidOption();
                    break;
            }

            Console.ReadKey();

        }

        public void CreateOption()
        {
            PersonRegistrationForm personRegistrationForm = PersonFactory.Create();

            Console.Clear();

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

            var result = _personService.Create(personRegistrationForm);

            if (result)
                OutputDialog("User was successfully created");
            else
                OutputDialog("User was not created");
            Console.ReadKey();
        }

        public void WieWOption()
        {
            Console.Clear();
            var persons = _personService.GetAll();
            foreach (var person in persons)
            {
                Console.WriteLine($"{"Id:",-5}{person.Id}");
                Console.WriteLine($"{"´Name:",-5}{person.FirstName} {person.LastName}");
                Console.WriteLine($"{"Id:",-5}{person.Email}");
                Console.WriteLine($"{"Id:",-5}{person.PhoneNumber}");
                Console.WriteLine($"{"Id:",-5}{person.StreetAddress}");
                Console.WriteLine($"{"Id:",-5}{person.PostCode}");
                Console.WriteLine($"{"Id:",-5}{person.Town}");    
            }
            Console.ReadKey();
        }

        public void DownloadOption()
        {
            Console.Clear();
            Console.ReadKey();
        }
        public void QuitOption()
        {
            Console.Clear();
            Console.WriteLine("Do You wanna qúit this application (y/n): ");
            var option = Console.ReadLine()!;
            if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

        public void InvalidOption ()
        {
            Console.Clear();
            Console.WriteLine("You must enter a valid option");  
        }

        public void OutputDialog (string message)
        {
            Console.Clear ();
            Console.WriteLine(message);
            Console.ReadKey();
        }


    }
}
