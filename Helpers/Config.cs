using EzPayloadSender.Models;
using System.Text.Json;

namespace EzPayloadSender.Helpers
{
    public class Config
    {
        #region PROPERTIES
        public string IpAdress = string.Empty;
        public string PayloadPathFilename = string.Empty;
        public int Port = 9090;
        public string? PayloadFilename => PayloadPathFilename != string.Empty ? Path.GetFileName(PayloadPathFilename) : string.Empty;
        public string? PayloadPath => PayloadPathFilename != string.Empty ? Path.GetDirectoryName(PayloadPathFilename) : Environment.CurrentDirectory;

        readonly string path = Path.Combine(Environment.CurrentDirectory, "EzPayloadSender.json");
        public bool CheckUpdateOnStartUp = true;
        public bool ShowConsole = true;
        #endregion
        #region FUNCTIONS
        public bool Load()
        {
            if (File.Exists(path))
            {
                string jsonFile = File.ReadAllText(path);
                var result = JsonSerializer.Deserialize<JSONConfig>(jsonFile);
                if (result != null && result is JSONConfig jsonConfig)
                {
                    IpAdress = jsonConfig.IpAdress;
                    Port = jsonConfig.Port;
                    PayloadPathFilename = jsonConfig.PayloadPathFilename;
                    ShowConsole = jsonConfig.ShowConsole;
                    CheckUpdateOnStartUp = jsonConfig.CheckUpdateOnStartUp;
                }
                if(!NetworkTools.IsValidIpAddress(IpAdress))
                {
                    IpAdress = string.Empty;
                }
                if (!NetworkTools.IsValidPort(Port))
                {
                    Port = 9090;
                }
                if (!File.Exists(PayloadPathFilename))
                {
                    PayloadPathFilename = string.Empty;
                }
            }
            return Save();
        }

        public bool Save()
        {
            try
            {
                JSONConfig jsonConfig = new()
                {
                    IpAdress = IpAdress ?? string.Empty,
                    Port = Port,
                    PayloadPathFilename = PayloadPathFilename,
                    ShowConsole = ShowConsole,
                    CheckUpdateOnStartUp = CheckUpdateOnStartUp
                };
                JsonSerializerOptions jsonSerializerOptions = new()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                JsonSerializerOptions options = jsonSerializerOptions;
                string json = JsonSerializer.Serialize(jsonConfig, options: options);
                File.WriteAllText(path, json);
                return true;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine(jsonEx.Message);
                return false;
            }
        }
        #endregion
    }
}
