using dyp.dyp;
using dyp.service.adapters;

namespace dyp.service
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Load(args);

            var personsRequestHandler = new PersonsRequestHandler();

            var server = new Server(personsRequestHandler);

            server.Run(Config.Address);
        }
    }
}
