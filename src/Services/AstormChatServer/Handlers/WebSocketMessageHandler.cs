using AstormChatServer.Models;
using AstormChatServer.SocketsManager;
using AstormDomain.Entities;
using AstormDomain.Enums;
using AstormPresistance.Contexts;
using Microsoft.EntityFrameworkCore;
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
        private readonly IServiceProvider _services;

        public WebSocketMessageHandler(ConnectionManager connections, IServiceProvider services) : base (connections) 
        {
            _services = services;
        }

        public override async Task OnConnected(WebSocket socket, Token token)
        {
            await base.OnConnected(socket, token);

            using (var scope = _services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<DataContext>();

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(token.Id));
                user.UserStatus = UserStatus.Online;

                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            await UserChangeStatus();

            //Connections.AddSocket(socket, token);

            //var socketId = Connections.GetId(socket);
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

            using (var scope = _services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<DataContext>();

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

        public override async Task OnDisconnected(WebSocket socket)
        {
            var userId = Connections.GetId(socket);
            await base.OnDisconnected(socket);

            using (var scope = _services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<DataContext>();

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(userId));
                user.UserStatus = UserStatus.Offline;

                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            await UserChangeStatus();
        }

        private async Task UserChangeStatus()
        {
            await SendMessageToAll("User update status");
        }
    }
}
