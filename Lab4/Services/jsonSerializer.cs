using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace Lab4.Serializers;
class JsonObjectSerializer<T>
{
    public List<T> ReadDataFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        return new List<T>();
    }

    public void WriteDataToFile(List<T> objects, string filePath)
    {
        string json = JsonSerializer.Serialize(objects);
        File.WriteAllText(filePath, json);
    }
}
