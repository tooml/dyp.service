using dyp.contracts.messages.queries.tournamentplayers;
using dyp.dyp.messagepipelines.queries.tournamentplayersquery;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentCompetitorsQueryController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Get, "/api/v1/tournament/competitors")]
        public TournamentCompetitorsQueryResult Load_tournament_competitors(string tournamentId)
        {
            Console.WriteLine($"tournament competitors query, tournament: { tournamentId }");

            using (var msgpump = new MessagePump())
            {
                var context_manager = new TournamentCompetitorsQueryContextManager(_es);
                var message_processor = new TournamentCompetitorsQueryContextProcessor();
                msgpump.Register<TournamentCompetitorsQuery>(context_manager, message_processor);

                var result = msgpump.Handle(new TournamentCompetitorsQuery() { TournamentId = tournamentId }) as TournamentCompetitorsQueryResult;
                return result;
            }
        }
    }
}
