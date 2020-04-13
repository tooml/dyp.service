using dyp.contracts.messages.commands.addplayer;
using dyp.dyp.messagepipelines.commands.changeplayerscommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class ChangePlayersCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament/players/change")]
        public HttpStatusCode Change_players([Payload] ChangePlayersCommand change_players_command)
        {
            Console.WriteLine($"change players command: { change_players_command.TournamentId }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new ChangePlayersCommandContextManager(_es);
                var message_processor = new ChangePlayersCommandProcessor();
                msgpump.Register<ChangePlayersCommand>(context_manager, message_processor);

                var result = msgpump.Handle(change_players_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
