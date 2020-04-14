using dyp.contracts.messages.commands.deletetournamentcommand;
using dyp.dyp.messagepipelines.commands.deletetournamentcommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class TournamentDeleteCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament/delete")]
        public HttpStatusCode Delete_tournament([Payload] DeleteTournamentCommand delete_tournament_command)
        {
            Console.WriteLine($"delete tournament command, id: { delete_tournament_command.Id }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new DeleteTournamentCommandContextManager(_es);
                var message_processor = new DeleteTournamentCommandProcessor();
                msgpump.Register<DeleteTournamentCommand>(context_manager, message_processor);

                var result = msgpump.Handle(delete_tournament_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
