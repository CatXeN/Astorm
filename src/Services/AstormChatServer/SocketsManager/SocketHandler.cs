﻿using AstormChatServer.Models;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AstormChatServer.SocketsManager
{
    public abstract class SocketHandler
    {
        public ConnectionManager Connections { get; set; }

        public SocketHandler(ConnectionManager connections)
        {
            Connections = connections;
        }

        public virtual async Task OnConnected(WebSocket socket, Token token)
        {
            await Task.Run(() => { Connections.AddSocket(socket, token); });
        }

        public virtual async Task OnDisconnected(WebSocket socket) => await Connections.RemoveSocketAsync(Connections.GetId(socket));

        public async Task SendMessage(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
                return;

            var bytesOfMessage = Encoding.UTF8.GetBytes(message);

            await socket.SendAsync(
                new ArraySegment<byte>(bytesOfMessage, 0, bytesOfMessage.Length),
                WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task SendMessage(string id, string Message) => await SendMessage(Connections.GetSocketById(id), Message);

        public async Task SendMessageToAll(string message)
        {
            foreach (var con in Connections.GetAllConnections())
                await SendMessage(con.Value, message);
        }

        public abstract Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer, Token token);
    }
}
