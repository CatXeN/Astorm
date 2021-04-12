using AstormChatServer.SocketsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AstormChatServer.Handlers
{
    public class WebSocketMessageHandler : SocketHandler
    {
        public WebSocketMessageHandler(ConnectionManager connections) : base (connections) {}

        public override async Task OnConnected(WebSocket socket, string token)
        {
            await base.OnConnected(socket, token);

            var socketId = Connections.GetId(socket);
            await SendMessageToAll($"{socketId} just joined :)");
        }

        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = Connections.GetId(socket);
            var message = $"{Encoding.UTF8.GetString(buffer, 0, result.Count)}"; //{socketId} said:
            await SendMessageToAll(message);
        }
    }
}
