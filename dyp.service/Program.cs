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

            var id_provider = new IdProvider();
            var date_provider = new DateProvider();

            var person_repo = new PersonRepository(Config.DbPath);
            var tournament_repo = new TournamentRepository(Config.DbPath);

            var director = new TournamentDirector(id_provider);

            var personStockQueryHandler = new PersonStockQueryHandler(person_repo);
            var newPersonQueryHandler = new NewPersonQueryHandler(id_provider);
            var storePersonCommandHandler = new StorePersonCommandHandler(person_repo);
            var createTournamentCommandHandler = new CreateTournamentCommandHandler(tournament_repo, person_repo, 
                                                                                    id_provider, date_provider, director);
            var tournamentQueryHandler = new TournamentQueryHandler(tournament_repo);

            var tournamentsInfoQueryHandler = new TournamentStockQueryHandler(tournament_repo);

            var server = new Server(personStockQueryHandler, newPersonQueryHandler, 
                                    storePersonCommandHandler, createTournamentCommandHandler,
                                    tournamentQueryHandler, tournamentsInfoQueryHandler);

            server.Run(Config.Address);
        }
    }
}
