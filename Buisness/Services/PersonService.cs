using System.Diagnostics;
using Buisness.Helpers;
using Buisness.Interfaces;
using mainApp.Factories;
using mainApp.Interfaces;
using mainApp.Models;

namespace mainApp.Services;

public class PersonService(IFileService fileService): IPersonService
{
    private List<PersonEntity> _persons = [];
    private readonly IFileService _fileService = fileService;

    public bool Create(PersonRegistrationForm form)
    {
        try
        {
            var personEntity = PersonFactory.Create(form);
            personEntity.Id = IdentifierGenerator.GenerateId();

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


