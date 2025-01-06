using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using mainApp.Interfaces;
using mainApp.Models;
using Newtonsoft.Json;

namespace mainApp.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "List.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }



    public bool SaveListToFile(List<Person> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_filePath, json);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }






    public string LoadListFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }

        return null!;

    }





}
