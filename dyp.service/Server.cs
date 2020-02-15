using dyp.provider.eventstore;
using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server()
        {
            var event_store = new EventStore(@"C:/test_bb");

            PersonStockQueryController._es = event_store;
            StorePersonCommandController._es = event_store;
            CreateTournamentCommandController._es = event_store;
            TournamentStockQueryController._es = event_store;
        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] 
            {
                typeof(ApiController),
                typeof(PersonStockQueryController),
                typeof(PersonTemplateQueryController),
                typeof(StorePersonCommandController),
                typeof(CreateTournamentCommandController),
                typeof(TournamentStockQueryController)
            });
        }
    }
}
