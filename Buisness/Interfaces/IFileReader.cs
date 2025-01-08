using mainApp.Models;

namespace mainApp.Interfaces;

public interface IFileReader
{
    List<Person> LoadListFromFile();
}
