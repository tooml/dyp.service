using dyp.service.adapters;

namespace dyp.service
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Load(args);

            var server = new Server();
            server.Run(Config.Address);
        }
    }
}
