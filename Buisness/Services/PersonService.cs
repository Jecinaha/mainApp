using System.Diagnostics;
using Buisness.Helpers;
using Buisness.Interfaces;
using mainApp.Factories;
using mainApp.Models;

namespace mainApp.Services;

public class PersonService : FileService, IPersonService
{
    private List<PersonEntity> _persons = [];
    private readonly FileService _fileService = new();

    public bool Create(PersonRegistrationForm form)
    {
        try
        {
            var personEntity = PersonFactory.Create(form);
            personEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();

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

    public void ClearList()
    {
        _persons.Clear();
    }

    public IEnumerable<Person> GetAll()
    {
        _persons = _fileService.LoadListFromFile();
        return _persons.Select(PersonFactory.Create);
    }
}


