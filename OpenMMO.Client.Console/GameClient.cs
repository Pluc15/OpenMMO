using OpenMMO.Client.Core.Clients;
using OpenMMO.Shared.Requests;
using OpenMMO.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenMMO.Client.Console
{
    public class GameInstance
    {
        private LoginClient _loginClient;
        private MapClient _mapClient;

        public GameInstance()
        {
            var _loginClient = new LoginClient(25120);
            var _mapClient = new MapClient(25121);
        }

        public async Task StartAsync()
        {
            await LoginAsync();
            var mapData = await GetMapDataAsync();
        }

        private async Task LoginAsync()
        {
            var loginPayload = new LoginRequest
            {
                Username = Request("Username"),
                Password = Request("Password")
            };
            await _loginClient
                .LoginAsync(loginPayload);
        }

        private async Task<MapDataResponse> GetMapDataAsync()
        {
            var mapDataRequest = new MapDataRequest();
            return await _mapClient
                .GetMapDataAsync(mapDataRequest);
        }

        private static string Request(string label)
        {
            System.Console.Write($"{label}: ");
            return System.Console.ReadLine();
        }
    }
}
