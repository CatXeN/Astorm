using AstormChatServer.Models;
using AstormChatServer.SocketsManager;
using AstormDomain.Entities;
using AstormPresistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AstormChatServer.Handlers
{
    public class WebSocketMessageHandler : SocketHandler
    {
        private readonly IServiceScope _scope;

        public WebSocketMessageHandler(ConnectionManager connections, IServiceProvider services) : base (connections) 
        {
            _scope = services.CreateScope();
        }

        public override async Task OnConnected(WebSocket socket, Token token)
        {
            await base.OnConnected(socket, token);

            var socketId = Connections.GetId(socket);
            //await SendMessageToAll($"{socketId} just joined :)");
        }

        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer, Token token)
        {
            var messageJson = new Message { Id = token.Id, Name = token.Name, Content = Encoding.UTF8.GetString(buffer, 0, result.Count) };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(messageJson, serializerSettings);

            var objectJson = JObject.Parse(json);
            var content = JObject.Parse(objectJson["content"].Value<string>());

            using (var _context = _scope.ServiceProvider.GetRequiredService<DataContext>())
            {
                var userId = Guid.Parse(content["userId"].Value<string>());
                var friendId = Guid.Parse(content["friendId"].Value<string>());                

                UserMessage userMessage = new UserMessage
                {
                    OwnerId = userId,
                    RecipientId = friendId,
                    Content = content["content"].Value<string>(),
                    SendMessageDate = DateTime.Now
                };

                await _context.UsersMessages.AddAsync(userMessage);
                await _context.SaveChangesAsync();
            }


            var message = $"{json}"; //{socketId} said:
            await SendMessageToAll(message);
        }
    }
}
