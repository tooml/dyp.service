using dyp.contracts.messages.queries.tournamentranking;
using dyp.dyp.messagepipelines.queries.tournamentrankingquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentRankingQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/tournament/ranking")]
        public TournamentRankingQueryResult Get_tournament_round(string tournamentId)
        {
            Console.WriteLine($"tournament ranking query, tournament: {tournamentId}");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new TournamentRankQueryContextManager(_es);
                var message_processor = new TournamentRankingQueryProcessor();
                msgpump.Register<TournamentRankingQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new TournamentRankingQuery() { TournamentId = tournamentId }) as TournamentRankingQueryResult;
                return result;
            }
        }
    }
}
