using System.ComponentModel.DataAnnotations;
using mainApp.Factories;
using mainApp.Models;
using Buisness.Interfaces;

namespace mainApp.Services
{
    public class MenuService(PersonService personService) : IMenuService
    {
        private readonly IPersonService _personService = personService;

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
                    Console.WriteLine("du måste ange ett giltigt alternativ");
                    Console.ReadKey();
                }
            }
        }
        public static string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("................MENY.................\n");
            Console.WriteLine($"{"1",-5} Lägg till personer");
            Console.WriteLine($"{"2",-5} Gå till adressboken");
            Console.WriteLine($"{"3",-5} Ladda ner adressboken");
            Console.WriteLine($"{"4",-5} Avsluta\n");
            Console.WriteLine(".....................................\n");
            Console.Write("Välj ditt alternativ: ");
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

            personRegistrationForm.FirstName = PromptAndValidate("Skriv in ditt förnamn: ", nameof(PersonRegistrationForm.FirstName));
            personRegistrationForm.LastName = PromptAndValidate("Skriv in ditt efternamn: ", nameof(PersonRegistrationForm.LastName));
            personRegistrationForm.Email = PromptAndValidate("Skriv in din email: ", nameof(PersonRegistrationForm.Email));
            personRegistrationForm.PhoneNumber = PromptAndValidate("Skriv in ditt telefonnummer: ", nameof(PersonRegistrationForm.PhoneNumber));
            personRegistrationForm.StreetAddress = PromptAndValidate("Skriv in din gatuadress: ", nameof(PersonRegistrationForm.StreetAddress));
            personRegistrationForm.PostCode = PromptAndValidate("Skriv in postnummer: ", nameof(PersonRegistrationForm.PostCode));
            personRegistrationForm.Town = PromptAndValidate("Skriv in ort: ", nameof(PersonRegistrationForm.Town));
            personRegistrationForm.FirstName = Console.ReadLine()!;

            bool result = _personService.Create(personRegistrationForm);
            
            if (result)
            {
                OutputDialog("Personen är tillagd i din adresslista");
            }
            else
            {
                OutputDialog("Personen gick inte att lägga till i din adresslista");
            }

        }

        public string PromptAndValidate(string prompt, string propertyName)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(prompt);
                var input = Console.ReadLine() ?? string.Empty;

                var result = new List<ValidationResult>();
                var context = new ValidationContext(new PersonRegistrationForm()) { MemberName = propertyName };

                if (Validator.TryValidateProperty(input, context, result))
                    return input;
                Console.WriteLine($"{result[0].ErrorMessage}. Försök igen");
            }
        }


        public void WiewAllPersons()
        {
            var persons = _personService.GetAll();

            Console.Clear();
            Console.WriteLine("............MIN ADRESSLISTA............\n");

            foreach (var person in persons)
            {
                Console.WriteLine($"\n{"Id: ",-5}{person.Id}");
                Console.WriteLine($"{"Namn: ",-5}{person.FirstName} {person.LastName}");
                Console.WriteLine($"{"Email: ",-5}{person.Email}");
                Console.WriteLine($"{"Telefonnummer: ",-5}{person.PhoneNumber}");
                Console.WriteLine($"{"Gatuadress: ",-5}{person.StreetAddress}");
                Console.WriteLine($"{"Postkod: ",-5}{person.PostCode}");
                Console.WriteLine($"{"Stad: ",-5}{person.Town}");
                Console.WriteLine("\n.....................................");
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
                Environment.Exit(0);
        }

        public static void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Du måste ange ett giltigt alternativ!");
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
