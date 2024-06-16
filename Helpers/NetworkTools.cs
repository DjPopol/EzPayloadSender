using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace EzPayloadSender.Helpers
{
    public  class NetworkTools
    {
        Socket? socket;
        CancellationTokenSource cts = new();
        public bool PsConnected;
        #region FUNCTIONS
        public void Cancel()
        {
            try
            {
                cts.Cancel();
                cts = new CancellationTokenSource(); // Réinitialise pour futures opérations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
                await socket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), Int32.Parse(port)),cts.Token);
                PsConnected = true;
                return string.Empty;
            }
            catch (SocketException ex)
            {
                PsConnected = false;
                return $"Socket error: {ex.Message}";
            }
            catch (OperationCanceledException)
            {
                PsConnected = false;
                return "Connection was canceled.";
            }
            catch (Exception ex)
            {
                PsConnected = false;
                return $"Error: {ex.Message}";
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
            try
            { 
                if(socket != null)
                {
                    await socket.SendFileAsync(filename, cts.Token);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket error: {ex.Message}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Sending was canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return;
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
