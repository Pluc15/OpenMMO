namespace OpenMMO.Server.Configurations
{
    public class BaseConfiguration
    {
        public BaseConfiguration()
        {
            Login = new LoginConfiguration();
            Map = new MapConfiguration();
        }

        public LoginConfiguration Login { get; set; }
        public MapConfiguration Map { get; set; }
    }
}
