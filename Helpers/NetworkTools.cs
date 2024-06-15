using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace EzPayloadSender.Helpers
{
    public  class NetworkTools
    {
        Socket? socket;
        CancellationTokenSource? cts;
        public bool PsConnected;
        #region FUNCTIONS
        public void Cancel()
        {
            cts?.Cancel();
        }
        public async Task<string> Connect2PS4Async(string ip, string port)
        {
            try
            {
                socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    ReceiveTimeout = 3000,
                    SendTimeout = 3000
                };
                await socket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), Int32.Parse(port)));
                PsConnected = true;
                return string.Empty;
            }
            catch (Exception ex)
            {
                PsConnected = false;
                return ex.ToString();
            }
        }
        public void DisconnectPayload()
        {
            PsConnected = false;
            socket?.Close();
        }
        public static async Task<bool> IsConnectedToInternetAsync()
        {
            try
            {
                using HttpClient client = new();
                client.Timeout = TimeSpan.FromSeconds(5);
                HttpResponseMessage response = await client.GetAsync("https://www.google.com");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public async Task SendPayloadAsync(string filename)
        {
            cts = new CancellationTokenSource();
            if(socket != null)
            {
                await socket.SendFileAsync(filename, cts.Token);
            }
        }
        #endregion
        #region STATIC FUNCTIONS
        public static bool IsValidIpAddress(string ipAddress)
        {
            string pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            return Regex.IsMatch(ipAddress, pattern);
        }
        public static bool IsValidPort(int port)
        {
            return port >= 0 && port <= 65535;
        }
        public static bool IsValidPort(string port)
        {
            return int.TryParse(port, out int intPort) && intPort >= 0 && intPort <= 65535;
        }
        #endregion
    }
}
