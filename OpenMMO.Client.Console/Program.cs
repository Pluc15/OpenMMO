using OpenMMO.Client.Core.Clients;
using OpenMMO.Shared.Requests;

namespace OpenMMO.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameInstance = new GameInstance();
            gameInstance.StartAsync().GetAwaiter().GetResult();
        }
    }
}
