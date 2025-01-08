using System.Diagnostics;
using Buisness.Helpers;
using Buisness.Interfaces;
using mainApp.Factories;
using mainApp.Models;

namespace mainApp.Services;

public class PersonService : FileService, IPersonService
{
    private readonly List<PersonEntity> _persons = [];
    private readonly FileService _fileService = new FileService();

    public bool Create(PersonRegistrationForm form)
    {
        try
        {
            var personEntity = PersonFactory.Create(form);
            personEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();

            _persons.Add(personEntity);
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
        return _persons.Select(PersonFactory.Create);
    }

}


