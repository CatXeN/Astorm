using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AstormServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
           // var token = ClientHelper.GetAuthorization().GetAwaiter().GetResult();

           // StartWebSockets(token).GetAwaiter().GetResult();
        }

        public static async Task StartWebSockets(string token)
        {
            var uri = new Uri("ws://localhost:5000/ws");

            var client = new ClientWebSocket();
            client.Options.Cookies = new CookieContainer();
            client.Options.Cookies.Add(new Cookie("token", token) { Domain = uri.Host});


            await client.ConnectAsync(uri, CancellationToken.None);
            Console.WriteLine($"web socket established @ {DateTime.Now:F}");

            var send = Task.Run(async () =>
            {
                string message;
                while ((message = Console.ReadLine()) != null && message != string.Empty)
                {
                    var bytes = Encoding.UTF8.GetBytes(message);
                    await client.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }

                await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            });

            var receive = ReceiveAsync(client);
            await Task.WhenAll(send, receive);
        }

        public static async Task ReceiveAsync(ClientWebSocket client)
        {
            var buffer = new byte[1024 * 4];

            while(true)
            {
                var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));

                if(result.MessageType == WebSocketMessageType.Close)
                {
                    await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    break;
                }
            }
        }
    }
}
