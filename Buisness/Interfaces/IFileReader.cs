using mainApp.Models;

namespace mainApp.Interfaces;

public interface IFileReader
{
    List<PersonEntity> LoadListFromFile();
}
