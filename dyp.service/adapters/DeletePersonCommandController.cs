using dyp.contracts.messages.commands.deleteperson;
using dyp.dyp.messagepipelines.commands.deletepersoncommand;
using dyp.messagehandling;
using dyp.provider.eventstore;
using servicehost.contract;
using System;
using System.Net;

namespace dyp.service.adapters
{
    [Service]
    public class DeletePersonCommandController
    {
        public static IEventStore _es;

        [EntryPoint(HttpMethods.Post, "/api/v1/person/delete")]
        public HttpStatusCode Delete_person([Payload] DeletePersonCommand delete_person_command)
        {
            Console.WriteLine($"delete person command, id: { delete_person_command.Id }");

            using (var msgpump = new MessagePump(_es))
            {
                var context_manager = new DeletePersonCommandContextManager(_es);
                var message_processor = new DeletePersonCommandProcessor();
                msgpump.Register<DeletePersonCommand>(context_manager, message_processor);

                var result = msgpump.Handle(delete_person_command) as CommandStatus;
                return (result is Success) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            }
        }
    }
}
