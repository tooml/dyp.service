using dyp.contracts.messages.commands.createtournament;
using dyp.contracts.messages.commands.storeperson;
using dyp.contracts.messages.queries.newperson;
using dyp.contracts.messages.queries.personstock;
using dyp.contracts.messages.queries.tournament;
using dyp.contracts.messages.queries.tournamentstock;
using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server(IPersonStockQueryHandling personStockQueryHandler, INewPersonQueryHandling newPersonQueryHandler, 
                      IStorePersonCommandHandling storePersonCommandHandler, ICreateTournamentCommandHandling createTournamentCommandHandler,
                      ITournamentQueryHandling tournamentQueryHandler, ITournamentStockQueryHandling tournamentStockQueryHandler)
        {
            PersonStockQueryController._personStockQueryHandler = () => personStockQueryHandler;
            NewPersonQueryController._newPersonQueryHandler = () => newPersonQueryHandler;
            StorePersonCommandController._storePersonCommandHandler = () => storePersonCommandHandler;
            CreateTournamentCommandController._createTournamentCommandHandling = () => createTournamentCommandHandler;
            TournamentQueryController._tournamentQueryHandling = () => tournamentQueryHandler;
            TournamentStockQueryController._newTournamentStockQueryHandler = () => tournamentStockQueryHandler;
        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] 
            {
                typeof(ApiController),
                typeof(PersonStockQueryController),
                typeof(NewPersonQueryController),
                typeof(StorePersonCommandController),
                typeof(CreateTournamentCommandController),
                typeof(TournamentQueryController),
                typeof(TournamentStockQueryController)
            });
        }
    }
}
