using AstormChatServer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace AstormChatServer.SocketsManager
{
    public class SocketMiddelware
    {
        private readonly RequestDelegate _next;
        private SocketHandler Handler { get; set; }

        public SocketMiddelware(RequestDelegate next, SocketHandler handler)
        {
            _next = next;
            Handler = handler;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
                return;
            
            var token = context.Request.Query.FirstOrDefault(x => x.Key == "token").Value;
            var socket = await context.WebSockets.AcceptWebSocketAsync();

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenDecoded = jsonToken as JwtSecurityToken;

            var tokenModel = new Token
            {
                Id = tokenDecoded.Claims.FirstOrDefault(x => x.Type == "nameid").Value,
                Name = tokenDecoded.Claims.FirstOrDefault(x => x.Type == "unique_name").Value
            };


            await Handler.OnConnected(socket, tokenModel);
            await Receive(socket, async (result, buffer) =>
            {
                if(result.MessageType == WebSocketMessageType.Text)
                {
                    await Handler.Receive(socket, result, buffer, tokenModel);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await Handler.OnDisconnected(socket);
                }
            });
        }

        private async Task Receive(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> messageToHandle)
        {
            var buffer = new byte[1024 * 4];

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                messageToHandle(result, buffer);
            }
        }
    }
}
