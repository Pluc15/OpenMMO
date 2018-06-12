namespace OpenMMO.Server.Handlers
{
    public interface IRequestHandler
    {
        void Handle(byte[] packet);
    }
}