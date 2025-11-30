using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class ConfigLoader
{
    public static List<T> LoadList<T>(string fileName)
    {
        var path = Path.Combine(Application.streamingAssetsPath, fileName);
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<T>>(json);
    }
}