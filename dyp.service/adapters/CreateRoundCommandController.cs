using dyp.adapter;
using dyp.contracts.messages.commands.createnewround;
using dyp.dyp.messagepipelines.commands.createroundcommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class CreateRoundCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament/round")]
        public HttpStatusCode Create_round([Payload] CreateRoundCommand create_round_command)
        {
            Console.WriteLine($"create round command: { create_round_command.TournamentId }");

            using (var msgpump = new MessagePump(_es))
            {
                var id_provider = new IdProvider();
          
                var context_manager = new CreateRoundCommandContextManager(_es);
                var message_processor= new CreateRoundCommandProcessor(id_provider);
                msgpump.Register<CreateRoundCommand>(context_manager, message_processor);

                var result = msgpump.Handle(create_round_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
