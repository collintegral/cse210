using System.Text.Json;

static class JsonHandler
{
    const string _filePath = "savedata.json";
    static readonly JsonSerializerOptions options = new() {WriteIndented = true, IncludeFields = true};

    public static void SaveData()
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(Program._parties, options));
    }

    public static void LoadData()
    {
        var fileTest = new FileInfo(_filePath);

        if (!fileTest.Exists)
        {
            File.Create(_filePath).Dispose();
            Program._parties = new List<Party>();
        }
        else if (File.ReadAllText(_filePath).Length != 0)
        {
            Program._parties = JsonSerializer.Deserialize<List<Party>>(File.ReadAllText(_filePath), options);
        }
        else
        {
            Program._parties = new List<Party>();
        }
    }
}