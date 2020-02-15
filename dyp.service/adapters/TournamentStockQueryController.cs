using dyp.contracts.messages.queries.tournamentstock;
using dyp.dyp.messagepipelines.queries.tournamentstockquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentStockQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/tournament/all")]
        public TournamentStockQueryResult Get_tournaments_infos()
        {
            Console.WriteLine("tournaments stock query");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new TournamentStockQueryContextManager(_es);
                var message_processor = new TournamentStockQueryProcessor();
                msgpump.Register<TournamentStockQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new TournamentStockQuery()) as TournamentStockQueryResult;
                return result;
            }
        }
    }
}
