using dyp.contracts.messages.commands.createtournament;
using dyp.contracts.messages.commands.storeperson;
using dyp.contracts.messages.queries.personstock;
using dyp.contracts.messages.queries.tournament;
using dyp.contracts.messages.queries.tournamentstock;
using dyp.dyp.messagepipelines.queries.personsstockquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using dyp.service.adapters;
using System;

namespace dyp.service
{
    public class Server
    {
        public Server()
        {
            //var black_box = new FolderBlackBox(@"C:/test_bb");
            //using (var msgpump = new MessagePump(black_box))
            //{
            //    var context_manager = new PersonStockQueryContextManager(black_box);
            //    var message_processor = new PersonStockQueryProcessor();
            //    msgpump.Register<PersonStockQuery>(context_manager, message_processor);


            //}



            var event_store = new EventStore(@"C:/test_bb");

            PersonStockQueryController._es = event_store;
            StorePersonCommandController._es = event_store;
            //NewPersonQueryController._newPersonQueryHandler = () => newPersonQueryHandler;
            //StorePersonCommandController._storePersonCommandHandler = () => storePersonCommandHandler;
            //CreateTournamentCommandController._createTournamentCommandHandling = () => createTournamentCommandHandler;
            //TournamentQueryController._tournamentQueryHandling = () => tournamentQueryHandler;
            //TournamentStockQueryController._newTournamentStockQueryHandler = () => tournamentStockQueryHandler;
        }

        public void Run(Uri address)
        {
            servicehost.ServiceHost.Run(address, new[] 
            {
                typeof(ApiController),
                typeof(PersonStockQueryController),
                typeof(PersonTemplateQueryController),
                typeof(StorePersonCommandController),
                //typeof(CreateTournamentCommandController),
                //typeof(TournamentQueryController),
                //typeof(TournamentStockQueryController)
            });
        }
    }
}
