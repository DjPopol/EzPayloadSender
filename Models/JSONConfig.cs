namespace EzPayloadSender.Models
{
    public class JSONConfig
    {
        public required bool CheckUpdateOnStartUp { get; set; }
        public required string IpAdress { get; set; }
        public required int Port { get; set; }
        public required string PayloadPathFilename { get; set; }
        public required bool ShowConsole { get; set; }
    }
}
