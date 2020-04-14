using dyp.contracts.messages.commands.changeoptions;
using dyp.dyp.messagepipelines.commands.changeoptionscommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using Nancy;
using servicehost.contract;
using System;

namespace dyp.service.adapters
{
    [Service]
    public class ChangeTournamentOptionsComandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament/options/change")]
        public HttpStatusCode Change_options([Payload] ChangeOptionsCommand change_options_command)
        {
            Console.WriteLine($"change options command: { change_options_command.TournamentId }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new ChangeOptionsCommandContextManager();
                var message_processor = new ChangeOptionsCommandProcessor();
                msgpump.Register<ChangeOptionsCommand>(context_manager, message_processor);

                var result = msgpump.Handle(change_options_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
