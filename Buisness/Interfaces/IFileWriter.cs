using mainApp.Models;

namespace mainApp.Interfaces;

public interface IFileWriter
 {
    void SaveListToFile(List<PersonEntity> persons);
 }
