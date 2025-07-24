using System.IO;
using System.Text.Json;

namespace DataClasses.ConfigurationClass;

public static class ConfigurationManager
{
    public static string? ConnectionString
    {
        get
        {
            string json = File.ReadAllText("appsettings.json");

            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            return root.GetProperty("DefaultConnection").GetString();
        }
    }
}
