using dyp.adapter;
using dyp.contracts.messages.commands.createtournament;
using dyp.dyp.messagepipelines.commands.createtournamentcommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class CreateTournamentCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/tournament")]
        public HttpStatusCode Create_tournament([Payload] CreateTournamentCommand create_tournament_command)
        {
            Console.WriteLine($"create tournament: { create_tournament_command.Name }");

            using (var msgpump = new MessagePump(_es))
            {
                var id_provider = new IdProvider();
                var date_provider = new DateProvider();

                var context_manager = new CreateTournamentCommandContextManager(_es);
                var message_processor = new CreateTournamentCommandProcessor(id_provider, date_provider);
                msgpump.Register<CreateTournamentCommand>(context_manager, message_processor);

                var result = msgpump.Handle(create_tournament_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
