namespace OpenMMO.Server.Configurations
{
    public class LoginConfiguration
    {
        public LoginConfiguration()
        {
            IpAddress = "127.0.0.1";
            Port = 25120;
        }

        public string IpAddress { get; set; }
        public int Port { get; set; }
    }
}