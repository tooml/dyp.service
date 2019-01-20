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
            var tournament_repo = new TournamentRepository(Config.DbPath);

            var director = new TournamentDirector();

            var personsRequestHandler = new PersonsRequestHandler(person_repo);
            var tournamentManagmentRequestHandler = new TournamentManagementRequestHandler(director, tournament_repo, person_repo);

            var server = new Server(personsRequestHandler, tournamentManagmentRequestHandler);

            server.Run(Config.Address);
        }
    }
}
