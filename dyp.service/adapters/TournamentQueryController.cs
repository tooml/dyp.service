using dyp.contracts.messages.queries.tournament;
using dyp.dyp.messagepipelines.queries.tournamentquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/tournament")]
        public TournamentQueryResult Load_tournament(string tournamentId)
        {
            Console.WriteLine($"tournament query, tournament: { tournamentId }");

            using (var msgpump = new MessagePump())
            {
                var context_manager = new TournamentQueryContextManager(_es);
                var message_processor = new TournamentQueryProcessor();
                msgpump.Register<TournamentQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new TournamentQuery() { TournamentId = tournamentId }) as TournamentQueryResult;
                return result;
            }
        }
    }
}
