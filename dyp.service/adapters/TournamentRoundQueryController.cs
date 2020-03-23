using dyp.contracts.messages.queries.tournamentround;
using dyp.dyp.messagepipelines.queries.tournamentroundquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentRoundQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/tournament/round/last")]
        public TournamentRoundQueryResult Get_tournament_round(string tournamentId)
        {
            Console.WriteLine($"tournament round query, tournament: {tournamentId}");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new TournamentRoundQueryContextManager(_es);
                var message_processor = new TournamentRoundQueryProcessor();
                msgpump.Register<TournamentRoundQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new TournamentRoundQuery() { TournamentId = tournamentId }) as TournamentRoundQueryResult;
                return result;
            }
        }
    }
}
