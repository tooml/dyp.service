using dyp.contracts.messages.commands.matchresult;
using dyp.dyp.messagepipelines.commands.matchresultcommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class MatchResultNotificationController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament/match/result")]
        public HttpStatusCode Store_match_result([Payload] MatchResultNotificationCommand match_result_command)
        {
            var results = string.Join(" ", match_result_command.Results);
            Console.WriteLine($"match result command, match: {match_result_command.MatchId}, result notification: { results }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new StoreMatchResultCommandContextManager(_es);
                var message_processor = new StoreMatchResultCommandProcessor();
                msgpump.Register<MatchResultNotificationCommand>(context_manager, message_processor);

                var result = msgpump.Handle(match_result_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
