using dyp.contracts.messages.commands.createtournament;
using dyp.contracts.messages.commands.storeperson;
using dyp.contracts.messages.queries.newperson;
using dyp.contracts.messages.queries.personstock;
using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server(IPersonStockQueryHandling personStockQueryHandler, INewPersonQueryHandling newPersonQueryHandler, 
                      IStorePersonCommandHandling storePersonCommandHandler, ICreateTournamentCommandHandling createTournamentCommandHandling)
        {
            PersonStockQueryController._personStockQueryHandler = () => personStockQueryHandler;
            NewPersonQueryController._newPersonQueryHandler = () => newPersonQueryHandler;
            StorePersonCommandController._storePersonCommandHandler = () => storePersonCommandHandler;
            CreateTournamentCommandController._createTournamentCommandHandling = () => createTournamentCommandHandling;
        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] 
            {
                typeof(ApiController),
                typeof(PersonStockQueryController),
                typeof(NewPersonQueryController),
                typeof(StorePersonCommandController),
                typeof(CreateTournamentCommandController)
            });
        }
    }
}
