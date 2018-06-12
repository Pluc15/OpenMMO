using OpenMMO.Server.Configurations;

namespace OpenMMO.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server(new BaseConfiguration());
            server.Start();
        }
    }
}
