using AstormChatServer.Models;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace AstormChatServer.SocketsManager
{
    public class ConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _connections = new ConcurrentDictionary<string, WebSocket>();

        public WebSocket GetSocketById(string id) => _connections.FirstOrDefault(x => x.Key == id).Value;

        public ConcurrentDictionary<string, WebSocket> GetAllConnections() => _connections;

        public string GetId(WebSocket socket) => _connections.FirstOrDefault(x => x.Value == socket).Key;

        public async Task RemoveSocketAsync(string id)
        {
            _connections.TryRemove(id, out var socket);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "socket connection closed", CancellationToken.None);
        }

        public void AddSocket(WebSocket socket, Token token)
        {   
            _connections.TryAdd(token.Id, socket);
        }
    }
}
