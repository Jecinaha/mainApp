using System.Diagnostics;
using System.Text.Json;
using mainApp.Interfaces;
using mainApp.Models;

namespace mainApp.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath = "Data", string fileName = "List.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public bool SaveListToFile(List<Person> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            
            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
            return true;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public List<Person> LoadListFromFile()
    {
       try
        {
            if (!File.Exists(_filePath))
                return [];

            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<Person>>(json, _jsonSerializerOptions);
            return list ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];  
        }
    }

}
