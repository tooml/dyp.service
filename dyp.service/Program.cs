using dyp.adapter;
using dyp.dyp;
using dyp.service.adapters;

namespace dyp.service
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Load(args);

            var person_repo = new PersonRepository(Config.DbPath);
            var personsRequestHandler = new PersonsRequestHandler(person_repo);

            var server = new Server(personsRequestHandler);

            server.Run(Config.Address);
        }
    }
}
