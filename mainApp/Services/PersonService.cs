using mainApp.Models;
using mainApp.Factories;
using System.Diagnostics;
using mainApp.Interfaces;

namespace mainApp.Services;

public class PersonService : IPersonService
{

    private List<PersonEntity> _persons = [];

    private readonly FileService _fileService = new();


    public bool Create(PersonRegistrationForm form)
    {
        try
        {
            PersonEntity personEntity = PersonFactory.Create(form);

            _persons.Add(personEntity);
            _fileService.SaveListToFile(_persons);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Person> GetAll()
    {
        _persons = _fileService.LoadListFromFile();
        return _persons.Select(PersonFactory.Create);
    }
}
