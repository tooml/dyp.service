using dyp.contracts.messages.commands.matchreset;
using dyp.dyp.messagepipelines.commands.matchresetcommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class MatchResetCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament/match/reset")]
        public HttpStatusCode Reset_match_result([Payload] MatchResetCommand match_reset_command)
        {
            Console.WriteLine($"reset match command: {match_reset_command.MatchId}");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new StoreMatchResetCommandContextManager(_es);
                var message_processor = new StoreMatchResetCommandContextProcessor();
                msgpump.Register<MatchResetCommand>(context_manager, message_processor);

                var result = msgpump.Handle(match_reset_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
