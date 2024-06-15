using System.Reflection;

namespace EzPayloadSender.Helpers
{
    public static class Tools
    {
        public static readonly string PathApp = Environment.CurrentDirectory;
        public static readonly string PathTmp = Path.Combine(Path.GetTempPath(), "EzPayloadSender");
        public static readonly Config MyConfig = new();
        public static void DeletePathTmp()
        {
            if (Directory.Exists(PathTmp))
            {
                Directory.Delete(PathTmp, true);
            }
        }
        public static string GetTitle()
        {
            return $"Ez Payload Sender v{ GetVersionStr() }";
        }
        public static string GetToken()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string? assemblyName = assembly.GetName().Name;
            if (assemblyName != null)
            {
                string resourceName = $"{assemblyName}.Resources.token.dp"; // Replace YourNamespace with your project's namespace

                using Stream stream = assembly.GetManifestResourceStream(resourceName) ?? throw new InvalidOperationException("Token file not found.");
                using StreamReader reader = new(stream);
                return reader.ReadToEnd().Trim();
            }
            return string.Empty;
        }
        public static string GetVersionStr()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version? version = assembly.GetName().Version;
            return version != null ? version.Major + "." + version.Minor + version.Revision : string.Empty;
        }
        public static Version GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return assembly.GetName().Version;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
    }
}
