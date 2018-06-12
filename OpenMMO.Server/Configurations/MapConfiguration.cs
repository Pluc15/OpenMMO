namespace OpenMMO.Server.Configurations
{
    public class MapConfiguration
    {
        public MapConfiguration()
        {
            IpAddress = "127.0.0.1";
            Port = 25121;
        }

        public string IpAddress { get; set; }
        public int Port { get; set; }
    }
}