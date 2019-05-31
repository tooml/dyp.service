using dyp.adapter;
using dyp.dyp;
using dyp.dyp.messagehandlers;
using dyp.dyp.provider;
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

            var id_provider = new IdProvider();

            var personStockQueryHandler = new PersonStockQueryHandler(person_repo);
            var newPersonQueryHandler = new NewPersonQueryHandler(id_provider);
            var storePersonCommandHandler = new StorePersonCommandHandler(person_repo);
            var createTournamentCommandHandler = new CreateTournamentCommandHandler();



            //var tournamentManagmentRequestHandler = new TournamentManagementRequestHandler(director, tournament_repo, person_repo);

            var server = new Server(personStockQueryHandler, newPersonQueryHandler, 
                                    storePersonCommandHandler, createTournamentCommandHandler);

            server.Run(Config.Address);
        }
    }
}
