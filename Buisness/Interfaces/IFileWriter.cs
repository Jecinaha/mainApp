using mainApp.Models;

namespace mainApp.Interfaces;

public interface IFileWriter
 {
    bool SaveListToFile(List<PersonEntity> persons);
 }
